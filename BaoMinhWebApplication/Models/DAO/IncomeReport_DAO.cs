using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BaoMinhWebApplication.Models;

namespace BaoMinhWebApplication.Models.DAO
{
    public static class IncomeReport_DAO
    {
        //Nếu mà có quyền returnn true ít nhất có vài quyền
        //Không return false
        public static bool createPermisionQuery(SqlCommand cmd,int[] Permisions, int AffiliationCode)
        {
            if (Permisions.Length == 0)
                return false;

            string randomParameterName = (new Guid()).ToString();
            cmd.CommandText += " AND ( dbo.ZTRNPF$.CNTBRANCH = @randomParameterName OR ("; // Should have some code here ???

            string PermisionQuery = "";
            //Với các permision thêm các nghiệp vụ tương ứng
            foreach(int Permision in Permisions)
            {
                switch(Permision)
                {
                    //Xe
                    case 0:
                        PermisionQuery += "LEFT([dbo].[ZTRNPF$].CNTTYPE,1) = 'V' OR";
                        break;

                    //Hàng hải
                    case 1:
                        PermisionQuery += "LEFT([dbo].[ZTRNPF$].CNTTYPE,1) = 'M' OR";
                        break;

                    //Kĩ thuật
                    case 2:
                        PermisionQuery += @"
(LEFT([dbo].[ZTRNPF$].CNTTYPE,1) != 'M'
OR LEFT([dbo].[ZTRNPF$].CNTTYPE,1) != 'V')";
                        break;
                }
            }

            PermisionQuery = PermisionQuery.Substring(0, PermisionQuery.LastIndexOf("OR"));
            cmd.CommandText += PermisionQuery;

            return true;
        }





        public static DataTable getDetails(string RLDGACCT)
        {
            string sql = $@"
SELECT DISTINCT 
dbo.ZTRNPF$.RLDGACCT AS 'MÃ ĐƠN',
dbo.ZTRNPF$.CNTTYPE AS'MÃ NGHIỆP VỤ',
dbo.ZTRNPF$.BATCTRCDE AS'TRANSACTION CODE',
dbo.ZTRNPF$.TRANNO AS 'SỐ TT GIAO DỊCH',
dbo.ZTRNPF$.TRANAMT01 AS 'PHÍ GROSS',
dbo.ZTRNPF$.TRANAMT03 AS 'GIẢM PHÍ',
dbo.ZTRNPF$.TRANAMT04 AS 'HOA HỒNG ĐẠI LÝ',
dbo.ZTRNPF$.TRANAMT06 AS 'PHÍ NET',
dbo.ZTRNPF$.TRANAMT07 AS 'THUẾ VAT',
dbo.ZTRNPF$.TRANAMT01 - dbo.ZTRNPF$.TRANAMT03 +dbo.ZTRNPF$.TRANAMT07 AS 'PHÍ KHÁCH HÀNG PHẢI TRẢ'
FROM dbo.AGNTPF$,dbo.CLNTPF$,dbo.DESCPF$, dbo.ZTRNPF$
INNER JOIN dbo.PREMPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.PREMPF$.CHDRNO
INNER JOIN dbo.RISKPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.RISKPF$.CHDRNO
INNER JOIN dbo.CHDRPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHDRPF$.CHDRNUM
INNER JOIN dbo.CHEXPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHEXPF$.CHDRNUM
WHERE 
dbo.AGNTPF$.AGNTNUM = dbo.ZTRNPF$.ACCNUM
AND dbo.CLNTPF$.CLNTNUM= dbo.CHDRPF$.COWNNUM
AND dbo.DESCPF$.DESCITEM= dbo.CHEXPF$.ZDEPTCD
AND dbo.CHDRPF$.TRANNO = dbo.ZTRNPF$.TRANNO
AND [RLDGACCT]= @RLDGACCT
";

            //Thêm parameter
            SqlCommand cmd = new SqlCommand(sql, Helper_DAO.createAndOpenConnection());

            if (string.IsNullOrEmpty(RLDGACCT))
            {
                return new DataTable();
            }

            cmd.Parameters.Add("@RLDGACCT", SqlDbType.NVarChar);
            cmd.Parameters["@RLDGACCT"].Value = RLDGACCT;           

            return Helper_DAO.getTable(cmd);

        }

        public static DataTable getIncomeReport()
        {
            string sql = $@"
SELECT DISTINCT
dbo.ZTRNPF$.CNTBRANCH AS 'MÃ CHI NHÁNH',
dbo.ZTRNPF$.BATCACTYR AS 'NĂM TÀI CHÍNH',
dbo.DESCPF$.LONGDESC AS  'TÊN PHÒNG BAN',
dbo.CHEXPF$.ZDEPTCD AS 'MÃ PHÒNG BAN',
dbo.ZTRNPF$.RLDGACCT AS 'MÃ ĐƠN',
dbo.CLNTPF$.LSURNAME AS 'HỌ VÀ TÊN LÓT',
dbo.CLNTPF$.LGIVNAME AS 'TÊN KHÁCH HÀNG',
dbo.ZTRNPF$.ACCNUM AS 'MÃ ĐẠI LÝ',
dbo.AGNTPF$.AGTYPE01 AS 'LOẠI ĐẠI LÝ',
dbo.ZTRNPF$.ORIGCURR AS 'ĐƠN VỊ TIỀN TỆ',
SUM(dbo.ZTRNPF$.TRANAMT01) AS 'PHÍ GROSS',
SUM(dbo.ZTRNPF$.TRANAMT03) AS 'GIẢM PHÍ',
SUM(dbo.ZTRNPF$.TRANAMT04) AS 'HOA HỒNG ĐẠI LÝ',
SUM(dbo.ZTRNPF$.TRANAMT06) AS 'PHÍ NET',
SUM(dbo.ZTRNPF$.TRANAMT07) AS 'THUẾ VAT',
SUM(dbo.ZTRNPF$.TRANAMT01 - dbo.ZTRNPF$.TRANAMT03 +dbo.ZTRNPF$.TRANAMT07) AS 'PHÍ KHÁCH HÀNG PHẢI TRẢ',
dbo.ZTRNPF$.CCDATE AS 'NGÀY HIỆU LỰC ĐƠN',
dbo.CHDRPF$.PAYPLAN AS 'MÃ KỲ PHÍ' 
FROM dbo.AGNTPF$,dbo.CLNTPF$,dbo.DESCPF$, dbo.ZTRNPF$
INNER JOIN dbo.PREMPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.PREMPF$.CHDRNO
INNER JOIN dbo.RISKPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.RISKPF$.CHDRNO
INNER JOIN dbo.CHDRPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHDRPF$.CHDRNUM
INNER JOIN dbo.CHEXPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHEXPF$.CHDRNUM
WHERE 
dbo.AGNTPF$.AGNTNUM = dbo.ZTRNPF$.ACCNUM
AND dbo.CLNTPF$.CLNTNUM= dbo.CHDRPF$.COWNNUM
AND dbo.DESCPF$.DESCITEM= dbo.CHEXPF$.ZDEPTCD
AND dbo.CHDRPF$.TRANNO = dbo.ZTRNPF$.TRANNO

GROUP BY
dbo.ZTRNPF$.CNTBRANCH ,
dbo.ZTRNPF$.BATCACTYR ,
dbo.DESCPF$.LONGDESC,
dbo.CHEXPF$.ZDEPTCD ,
dbo.ZTRNPF$.RLDGACCT ,
dbo.CLNTPF$.LSURNAME ,
dbo.CLNTPF$.LGIVNAME ,
dbo.ZTRNPF$.ACCNUM ,
dbo.AGNTPF$.AGTYPE01 ,
dbo.ZTRNPF$.ORIGCURR ,
dbo.ZTRNPF$.CCDATE ,
dbo.CHDRPF$.PAYPLAN

ORDER BY dbo.ZTRNPF$.RLDGACCT";

            SqlCommand cmd = new SqlCommand(sql, Helper_DAO.createAndOpenConnection());
            return Helper_DAO.getTable(cmd);
        }

        public static void SearchArray(SqlCommand cmd,string SqlName,string ParamName,object[] ParamArray)
        {
            if (ParamArray == null) return;

            int ParamCount = ParamArray.Count();
            if (ParamCount == 0) return;

            List<string> ParamNames = new List<string>();
            for(int i=0;i< ParamCount; i++)
            {
                cmd.Parameters.AddWithValue($"{ParamName}{i}", ParamArray[i]);
                ParamNames.Add($"@{ParamName}{i}");
            }

            string parajoin = string.Join(",", ParamNames);
            cmd.CommandText += $" AND {SqlName} in ({parajoin})";

        }

        public static DataTable getNextIncomeReports(
            string keyNextBoundary,
            int numDisplayItem,
            FilterIncomeReportViewModel SearchViewModel,
            ICollection<Nhom> authorizedGroups
            )
        {
            //Nếu permission rỗng

            string sql =  $@"
SELECT DISTINCT TOP (@numDisplayItem)
dbo.ZTRNPF$.CNTBRANCH AS 'MÃ CHI NHÁNH',
dbo.ZTRNPF$.BATCACTYR AS 'NĂM TÀI CHÍNH',
dbo.DESCPF$.LONGDESC AS  'TÊN PHÒNG BAN',
dbo.CHEXPF$.ZDEPTCD AS 'MÃ PHÒNG BAN',
dbo.ZTRNPF$.RLDGACCT AS 'MÃ ĐƠN',
dbo.CLNTPF$.LSURNAME AS 'HỌ VÀ TÊN LÓT',
dbo.CLNTPF$.LGIVNAME AS 'TÊN KHÁCH HÀNG',
dbo.ZTRNPF$.ACCNUM AS 'MÃ ĐẠI LÝ',
dbo.AGNTPF$.AGTYPE01 AS 'LOẠI ĐẠI LÝ',
dbo.ZTRNPF$.ORIGCURR AS 'ĐƠN VỊ TIỀN TỆ',
SUM(dbo.ZTRNPF$.TRANAMT01) AS 'PHÍ GROSS',
SUM(dbo.ZTRNPF$.TRANAMT03) AS 'GIẢM PHÍ', 
SUM(dbo.ZTRNPF$.TRANAMT04) AS 'HOA HỒNG ĐẠI LÝ',
SUM(dbo.ZTRNPF$.TRANAMT06) AS 'PHÍ NET',
SUM(dbo.ZTRNPF$.TRANAMT07) AS 'THUẾ VAT',
SUM(dbo.ZTRNPF$.TRANAMT01 - dbo.ZTRNPF$.TRANAMT03 +dbo.ZTRNPF$.TRANAMT07) AS 'PHÍ KHÁCH HÀNG PHẢI TRẢ',
dbo.ZTRNPF$.CCDATE AS 'NGÀY HIỆU LỰC ĐƠN',
dbo.CHDRPF$.PAYPLAN AS 'MÃ KỲ PHÍ'
FROM dbo.AGNTPF$,dbo.CLNTPF$,dbo.DESCPF$, dbo.ZTRNPF$
INNER JOIN dbo.PREMPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.PREMPF$.CHDRNO
INNER JOIN dbo.RISKPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.RISKPF$.CHDRNO
INNER JOIN dbo.CHDRPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHDRPF$.CHDRNUM
INNER JOIN dbo.CHEXPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHEXPF$.CHDRNUM
WHERE 
dbo.AGNTPF$.AGNTNUM = dbo.ZTRNPF$.ACCNUM
AND dbo.CLNTPF$.CLNTNUM= dbo.CHDRPF$.COWNNUM
AND dbo.DESCPF$.DESCITEM= dbo.CHEXPF$.ZDEPTCD
AND dbo.CHDRPF$.TRANNO = dbo.ZTRNPF$.TRANNO";



            //Thêm parameter
            SqlCommand cmd = new SqlCommand(sql, Helper_DAO.createAndOpenConnection());

            if (!string.IsNullOrEmpty(keyNextBoundary)) // Nếu chuỗi rỗng không so sánh
            {
                cmd.CommandText += $" AND dbo.ZTRNPF$.RLDGACCT > @keyNextBoundary";
                cmd.Parameters.Add("keyNextBoundary", SqlDbType.NVarChar);
                cmd.Parameters["keyNextBoundary"].Value = keyNextBoundary;
            }

            /*Ngày Hiệu lực đơn từ*/
            if (!string.IsNullOrEmpty(SearchViewModel.NgayHieuLucTu)) // Nếu chuỗi rỗng không so sánh
            {
                cmd.CommandText += $" AND dbo.ZTRNPF$.CCDATE >= @NgayHieuLucTu";
                cmd.Parameters.Add("NgayHieuLucTu", SqlDbType.NVarChar);
                cmd.Parameters["NgayHieuLucTu"].Value = SearchViewModel.NgayHieuLucTu;
            }

            /*Ngày Hiệu lực đơn tới*/
            if (!string.IsNullOrEmpty(SearchViewModel.NgayHieuLucDen)) // Nếu chuỗi rỗng không so sánh
            {
                cmd.CommandText += $" AND dbo.ZTRNPF$.CCDATE <= @NgayHieuLucDen";
                cmd.Parameters.Add("NgayHieuLucDen", SqlDbType.NVarChar);
                cmd.Parameters["NgayHieuLucDen"].Value = SearchViewModel.NgayHieuLucDen;
            }

            /*Mã chi nhánh*/
            //Đặt cờ nếu có it nhất 1 quyền thì Ok, không có quyền thì return datatable rỗng
            bool IsHavingAtLeastOnePermision = false;

            if (SearchViewModel.DanhSachChiNhanh!=null && SearchViewModel.DanhSachChiNhanh.Count()>0) // Nếu chuỗi rỗng không so sánh
            {
                

                //List<string> parameters = new List<string>();
                //for (int i = 0; i <= SearchViewModel.DanhSachChiNhanh.Length-1; i++)
                //{
                //    parameters.Add(string.Format("@DanhSachChiNhanh{0}", i));
                //    cmd.Parameters.AddWithValue(parameters[i], SearchViewModel.DanhSachChiNhanh[i].value[0]);
                //}

                //string parajoin = string.Join(",", parameters);

                //cmd.CommandText += $" AND dbo.ZTRNPF$.CNTBRANCH in ({parajoin})";
                Entities entities = new Entities();
                foreach (Nhom group in authorizedGroups)
                {
                    //Mỗi chi nhánh của nhóm
                    foreach (NhomThuocChiNhanh affiliationInGroup in group.NhomThuocChiNhanh)
                    {
                        if (SearchViewModel.DanhSachChiNhanh.Where(p=>p.value==affiliationInGroup.id.ToString()).Count()>0)
                        {
                            //Test quyền Quyền xem có không

                            if (createPermisionQuery(
                                cmd,
                                affiliationInGroup.QuyenXem_NhomThuocChiNhanh.Select(p => p.id).ToArray(),
                                affiliationInGroup.MaChiNhanh))
                                IsHavingAtLeastOnePermision = true;
                        }

                    }
                }

            }
            else
            {
                //Lấy tất cả chi nhánh được cấp quyền

                //Mỗi nhóm của tài khoản
                foreach (Nhom group in authorizedGroups)
                {
                    //Mỗi chi nhánh của nhóm
                    foreach(NhomThuocChiNhanh affiliationInGroup in group.NhomThuocChiNhanh)
                    {
                        //Quyền xem
                        if(createPermisionQuery(
                                cmd,
                                affiliationInGroup.QuyenXem_NhomThuocChiNhanh.Select(p => p.id).ToArray(),
                                affiliationInGroup.MaChiNhanh))
                            IsHavingAtLeastOnePermision = true;
                    } 
                }
            }

            //Nếu không có quyền nào trả về datatable rỗng
            if (!IsHavingAtLeastOnePermision)
                return new DataTable();

            ///*Mã Phòng bah*/
            //if (SearchViewModel.DanhSachPhongBan != null && SearchViewModel.DanhSachPhongBan.Count() > 0) // Nếu chuỗi rỗng không so sánh
            //{
            //    List<string> parameters = new List<string>();
            //    for (int i = 0; i <= SearchViewModel.DanhSachPhongBan.Length - 1; i++)
            //    {
            //        parameters.Add(string.Format("@DanhSachPhongBan{0}", i));
            //        cmd.Parameters.AddWithValue(parameters[i], SearchViewModel.DanhSachPhongBan[i].value[0]);
            //    }

            //    string parajoin = string.Join(",", parameters);

            //    cmd.CommandText += $" AND dbo.CHEXPF$.ZDEPTCD in ({parajoin})";
            //}

            ///*Loại đại lý*/
            //if (SearchViewModel.DanhSachLoaiDaiLy != null && SearchViewModel.DanhSachLoaiDaiLy.Count() > 0) // Nếu chuỗi rỗng không so sánh
            //{
            //    List<string> parameters = new List<string>();
            //    for (int i = 0; i <= SearchViewModel.DanhSachLoaiDaiLy.Length - 1; i++)
            //    {
            //        parameters.Add(string.Format("@DanhSachLoaiDaiLy{0}", i));
            //        cmd.Parameters.AddWithValue(parameters[i], SearchViewModel.DanhSachLoaiDaiLy[i].value[0]);
            //    }

            //    string parajoin = string.Join(",", parameters);

            //    cmd.CommandText += $" AND dbo.AGNTPF$.AGTYPE01 in ({parajoin})";
            //}

            ///*Mã đại lý*/
            //if (SearchViewModel.DanhSachMaDaiLy != null && SearchViewModel.DanhSachMaDaiLy.Count() > 0) // Nếu chuỗi rỗng không so sánh
            //{
            //    List<string> parameters = new List<string>();
            //    for (int i = 0; i <= SearchViewModel.DanhSachMaDaiLy.Length - 1; i++)
            //    {
            //        parameters.Add(string.Format("@DanhSachMaDaiLy{0}", i));
            //        cmd.Parameters.AddWithValue(parameters[i], SearchViewModel.DanhSachMaDaiLy[i].value[0]);
            //    }

            //    string parajoin = string.Join(",", parameters);

            //    cmd.CommandText += $" AND dbo.ZTRNPF$.ACCNUM in ({parajoin})";
            //}

            /*Họ tên khách hàng*/
            //if (SearchViewModel.DanhSachChiNhanh != null && SearchViewModel.DanhSachHoTenKhachHang.Count() > 0) // Nếu chuỗi rỗng không so sánh
            //{
            //    List<string> parametersHoKhachHang = new List<string>();
            //    for (int i = 0; i <= SearchViewModel.DanhSachHoTenKhachHang.Length - 1; i++)
            //    {
            //        parametersHoKhachHang.Add(string.Format("@DanhSachHoKhachHang{0}", i));
            //        cmd.Parameters.AddWithValue(
            //            parametersHoKhachHang[i],
            //            SearchViewModel.DanhSachHoTenKhachHang[i].label);

            //    }

            //    string paraHojoin = string.Join(",", parametersHoKhachHang);

            //    cmd.CommandText += $" AND dbo.CLNTPF$.LSURNAME+' '+dbo.CLNTPF$.LGIVNAME in ({paraHojoin})";
            //}


            //if(!String.IsNullOrEmpty(SearchViewModel.HoTenKhachHang))
            //{
            //    cmd.Parameters.Add("Surname", SqlDbType.NVarChar, 50);
            //    cmd.Parameters["Surname"].Value =  SearchViewModel.HoTenKhachHang;

            //    cmd.Parameters.Add("Givname", SqlDbType.NVarChar, 50);
            //    cmd.Parameters["Givname"].Value = SearchViewModel.HoTenKhachHang;


            //    cmd.CommandText += $" AND ( dbo.CLNTPF$.LSURNAME COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%'+@Surname+'%'";
            //    cmd.CommandText += $" OR dbo.CLNTPF$.LGIVNAME COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%'+Givname+'%')";
            //}

            //cmd.CommandText += $" AND dbo.CLNTPF$. COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%PHUONG%'";

            /*Nghiệp vụ*/
            if (SearchViewModel.DanhSachNghiepVu != null) // Nếu chuỗi rỗng không so sánh
            {
                SearchArray(cmd, "[dbo].[RISKPF$].PREMCL", "PREMCL", SearchViewModel.DanhSachNghiepVu.PREMCL);
                SearchArray(cmd, "[dbo].[RISKPF$].RSKTYP", "RSKTYP", SearchViewModel.DanhSachNghiepVu.RSKTYP);

            }

            cmd.CommandText += @" 

GROUP BY
dbo.ZTRNPF$.CNTBRANCH ,
dbo.ZTRNPF$.BATCACTYR ,
dbo.DESCPF$.LONGDESC,
dbo.CHEXPF$.ZDEPTCD ,
dbo.ZTRNPF$.RLDGACCT ,
dbo.CLNTPF$.LSURNAME ,
dbo.CLNTPF$.LGIVNAME ,
dbo.ZTRNPF$.ACCNUM ,
dbo.AGNTPF$.AGTYPE01 ,
dbo.ZTRNPF$.ORIGCURR ,
dbo.ZTRNPF$.CCDATE ,
dbo.CHDRPF$.PAYPLAN

ORDER BY dbo.ZTRNPF$.RLDGACCT";

            //Para for numdisplay item
            cmd.Parameters.Add("numDisplayItem", SqlDbType.Int);

            //Nếu có quyền
            cmd.Parameters["numDisplayItem"].Value = numDisplayItem;

            //Nếu không có quyền
            cmd.Parameters["numDisplayItem"].Value = 0;

            return Helper_DAO.getTable(cmd);
        }

        public static DataTable getPrevIncomeReports(
            string keyPrevBoundary,
            int numDisplayItem

            )
        {
            string sql =  $@"
SELECT * FROM
(
SELECT DISTINCT TOP (@numDisplayIten)
dbo.ZTRNPF$.CNTBRANCH AS 'MÃ CHI NHÁNH',
dbo.ZTRNPF$.BATCACTYR AS 'NĂM TÀI CHÍNH',
dbo.DESCPF$.LONGDESC AS  'TÊN PHÒNG BAN',
dbo.CHEXPF$.ZDEPTCD AS 'MÃ PHÒNG BAN',
dbo.ZTRNPF$.RLDGACCT AS 'MÃ ĐƠN',
dbo.CLNTPF$.LSURNAME AS 'HỌ VÀ TÊN LÓT',
dbo.CLNTPF$.LGIVNAME AS 'TÊN KHÁCH HÀNG',
dbo.ZTRNPF$.ACCNUM AS 'MÃ ĐẠI LÝ',
dbo.AGNTPF$.AGTYPE01 AS 'LOẠI ĐẠI LÝ',
dbo.ZTRNPF$.ORIGCURR AS 'ĐƠN VỊ TIỀN TỆ',
SUM(dbo.ZTRNPF$.TRANAMT01) AS 'PHÍ GROSS',
SUM(dbo.ZTRNPF$.TRANAMT03) AS 'GIẢM PHÍ',
SUM(dbo.ZTRNPF$.TRANAMT04) AS 'HOA HỒNG ĐẠI LÝ',
SUM(dbo.ZTRNPF$.TRANAMT06) AS 'PHÍ NET',
SUM(dbo.ZTRNPF$.TRANAMT07) AS 'THUẾ VAT',
SUM(dbo.ZTRNPF$.TRANAMT01 - dbo.ZTRNPF$.TRANAMT03 +dbo.ZTRNPF$.TRANAMT07) AS 'PHÍ KHÁCH HÀNG PHẢI TRẢ',
dbo.ZTRNPF$.CCDATE AS 'NGÀY HIỆU LỰC ĐƠN',
dbo.CHDRPF$.PAYPLAN AS 'MÃ KỲ PHÍ'
FROM dbo.AGNTPF$,dbo.CLNTPF$,dbo.DESCPF$, dbo.ZTRNPF$
INNER JOIN dbo.PREMPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.PREMPF$.CHDRNO
INNER JOIN dbo.RISKPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.RISKPF$.CHDRNO
INNER JOIN dbo.CHDRPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHDRPF$.CHDRNUM
INNER JOIN dbo.CHEXPF$ ON dbo.ZTRNPF$.RLDGACCT = dbo.CHEXPF$.CHDRNUM

WHERE 
dbo.AGNTPF$.AGNTNUM = dbo.ZTRNPF$.ACCNUM
AND dbo.CLNTPF$.CLNTNUM= dbo.CHDRPF$.COWNNUM
AND dbo.DESCPF$.DESCITEM= dbo.CHEXPF$.ZDEPTCD
AND dbo.CHDRPF$.TRANNO = dbo.ZTRNPF$.TRANNO
AND dbo.ZTRNPF$.RLDGACCT < @keyPrevBoundary

GROUP BY
dbo.ZTRNPF$.CNTBRANCH ,
dbo.ZTRNPF$.BATCACTYR ,
dbo.DESCPF$.LONGDESC,
dbo.CHEXPF$.ZDEPTCD ,
dbo.ZTRNPF$.RLDGACCT ,
dbo.CLNTPF$.LSURNAME ,
dbo.CLNTPF$.LGIVNAME ,
dbo.ZTRNPF$.ACCNUM ,
dbo.AGNTPF$.AGTYPE01 ,
dbo.ZTRNPF$.ORIGCURR ,
dbo.ZTRNPF$.CCDATE ,
dbo.CHDRPF$.PAYPLAN 

ORDER BY dbo.ZTRNPF$.RLDGACCT DESC
) REVERSE_SET
ORDER BY REVERSE_SET.[MÃ ĐƠN] ";

            SqlCommand cmd = new SqlCommand(sql, Helper_DAO.createAndOpenConnection());
            cmd.Parameters.Add("@keyPrevBoundary", SqlDbType.NVarChar);

            if (string.IsNullOrEmpty(keyPrevBoundary))
                keyPrevBoundary = ".";

            cmd.Parameters["@keyPrevBoundary"].Value = keyPrevBoundary;


            return Helper_DAO.getTable(cmd);
        }
    }
}