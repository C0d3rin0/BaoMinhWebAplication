using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BaoMinhWebApplication.Models.DAO
{
    static public class FilterData_DAO
    {
        public static DataTable layDanhSachChiNhanhh()
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT [id] as 'value'
      ,[name]
      , [name] + '['+cast([id] as varchar)+']' as 'label'
  FROM [DevDB].[dbo].[PQDONVI$]", 
Helper_DAO.createAndOpenConnection());

            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layDanhSachPhongBanTheoTenHoacMa(string NoiDung)
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT TOP 10 [DESCITEM] as 'value'
      ,[LONGDESC] as 'name'
      , [LONGDESC] +' ['+[DESCITEM]+']' as 'label'
  FROM [DevDB].[dbo].[DESCPF$]
  WHERE [DESCITEM] <> '' AND ([DESCITEM] LIKE @NoiDung OR [LONGDESC] LIKE @NoiDung)",
Helper_DAO.createAndOpenConnection());

            cmd.Parameters.Add("NoiDung", SqlDbType.NVarChar, 255);
            cmd.Parameters["NoiDung"].Value = '%'+NoiDung.Trim()+'%';
            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layHoTenKhachHang(string NoiDung)
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT TOP 10 dbo.CLNTPF$.LSURNAME AS 'surName',
dbo.CLNTPF$.LGIVNAME AS 'givName',
LSURNAME + ' ' + LGIVNAME AS 'label'
FROM [DevDB].[dbo].[CLNTPF$]
WHERE ([LSURNAME] LIKE @NoiDung OR [LGIVNAME] LIKE @NoiDung)
",
Helper_DAO.createAndOpenConnection());

            cmd.Parameters.Add("NoiDung", SqlDbType.NVarChar, 255);
            cmd.Parameters["NoiDung"].Value = '%' + NoiDung.Trim() + '%';
            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layMaDaiLy(string NoiDung)
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT TOP 10  [AGNTNUM] as 'value'
FROM [DevDB].[dbo].[AGNTPF$]
WHERE ([AGNTNUM] LIKE @NoiDung)",
Helper_DAO.createAndOpenConnection());

            cmd.Parameters.Add("NoiDung", SqlDbType.NVarChar, 255);
            cmd.Parameters["NoiDung"].Value = '%' + NoiDung.Trim() + '%';
            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layLoaiDaiLy()
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT DISTINCT  AGTYPE01 as 'value'
FROM [DevDB].[dbo].[AGNTPF$]
",
Helper_DAO.createAndOpenConnection());
            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layNghiepVuXe()
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT DISTINCT [dbo].[RISKPF$].RSKTYP, 
[dbo].[PREMPF$].PREMCL
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
AND LEFT([dbo].[ZTRNPF$].CNTTYPE,1) = 'V'",
Helper_DAO.createAndOpenConnection());
            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layNghiepVuHangHai()
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT DISTINCT [dbo].[RISKPF$].RSKTYP, 
[dbo].[PREMPF$].PREMCL
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
AND LEFT([dbo].[ZTRNPF$].CNTTYPE,1) = 'M'",
Helper_DAO.createAndOpenConnection());
            return Helper_DAO.getTable(cmd);
        }

        public static DataTable layNghiepVuKiThuat()
        {
            SqlCommand cmd = new SqlCommand(
@"SELECT DISTINCT [dbo].[RISKPF$].RSKTYP, 
[dbo].[PREMPF$].PREMCL
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
AND LEFT([dbo].[ZTRNPF$].CNTTYPE,1) != 'M'
AND LEFT([dbo].[ZTRNPF$].CNTTYPE,1) != 'V'",
Helper_DAO.createAndOpenConnection());
            return Helper_DAO.getTable(cmd);
        }   
    }
}