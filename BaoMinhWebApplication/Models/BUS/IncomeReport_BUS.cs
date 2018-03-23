using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BaoMinhWebApplication;
using BaoMinhWebApplication.Models.DAO;
using System.IO;
using ClosedXML.Excel;

namespace BaoMinhWebApplication.Models.BUS
{
    public static class IncomeReport_BUS
    {
        //public static NghiepVuViewModel[] layNghiepVu()
        //{
        //    NghiepVuViewModel Xe = new NghiepVuViewModel();
        //    Xe.id = "|Xe";
        //    Xe.label = "Nghiệp vụ xe";
        //    Xe.children = FilterData_DAO.layNghiepVuXe();

        //    NghiepVuViewModel HangHai = new NghiepVuViewModel();
        //    HangHai.id = "|HangHai";
        //    HangHai.label = "Nghiệp vụ hàng hải";
        //    HangHai.children = FilterData_DAO.layNghiepVuHangHai();

        //    NghiepVuViewModel KT = new NghiepVuViewModel();
        //    KT.id = "|KyThuat";
        //    KT.label = "Nghiệp vụ kĩ thuật";
        //    KT.children = FilterData_DAO.layNghiepVuKiThuat();


        //    return new NghiepVuViewModel[] { Xe, HangHai, KT };
        //}}

        public static Stream createExcel()
        {
            DataTable dt = IncomeReport_DAO.getIncomeReport();
            var workBook = new XLWorkbook();
            workBook.AddWorksheet(dt,"Export");
            Stream fs = new MemoryStream();
            workBook.SaveAs(fs);
            fs.Position = 0;
            return fs;
        }

        public static IncomeReportRemoteSearchViewModel getNextIncomeReports(
            string keyNextBoundary,
            int numDisplayItem,
            FilterIncomeReportViewModel SearchViewModel,
            ICollection<Nhom> AuthorizedGroups)
        {
            IncomeReportRemoteSearchViewModel ViewModel = new IncomeReportRemoteSearchViewModel();
            DataTable dt = IncomeReport_DAO.getNextIncomeReports(keyNextBoundary, numDisplayItem + 1,SearchViewModel, AuthorizedGroups);

            int rowCount = dt.Rows.Count;
            ViewModel.isFirstPage = String.IsNullOrEmpty(keyNextBoundary)?true:false;


            // Lấy hơn một dòng để kiểm tra phía trước còn dòng nào
            ViewModel.isLastPage = rowCount <= numDisplayItem ? true : false;

            ViewModel.data = dt;

            //Tính toán để duy chuyển
            if(rowCount > numDisplayItem)
            {
                ViewModel.data.Rows.RemoveAt(rowCount - 1); // dòng cuối là dummy
                ViewModel.keyPrevBoundary = ViewModel.data.Rows[0]["MÃ ĐƠN"].ToString();
                ViewModel.keyNextBoundary = ViewModel.data.Rows[rowCount - 2]["MÃ ĐƠN"].ToString();
            }
            else if(rowCount>0)
            {
                ViewModel.keyPrevBoundary = ViewModel.data.Rows[0]["MÃ ĐƠN"].ToString();
                ViewModel.keyNextBoundary = ViewModel.data.Rows[rowCount - 1]["MÃ ĐƠN"].ToString();
            }
            else // không tìm thấy thông tin nào trùng vào bộ lọc
            {
                ViewModel.isEmpty = true;
            }

            if(!ViewModel.isEmpty)
            {

                //Định dạng lai ngày tháng năm
                foreach(DataRow row in ViewModel.data.Rows)
                {
                    row["NGÀY HIỆU LỰC ĐƠN"] = Helper.convertToCorrectDateTime(row["NGÀY HIỆU LỰC ĐƠN"].ToString());
                }
            }

            return ViewModel;
        }

        public static IncomeReportRemoteSearchViewModel getPrevIncomeReports(
            string keyPrevBoundary,
            int numDisplayItem)
        {
            IncomeReportRemoteSearchViewModel ViewModel = new IncomeReportRemoteSearchViewModel();
            DataTable dt = IncomeReport_DAO.getPrevIncomeReports(keyPrevBoundary, numDisplayItem + 1);

            int rowCount = dt.Rows.Count;
            ViewModel.isLastPage = false;


            // Lấy hơn một dòng để kiểm tra phía trước còn dòng nào
            ViewModel.isFirstPage = rowCount <= numDisplayItem ? true : false;

            ViewModel.data = dt;

            if(rowCount<numDisplayItem&&rowCount>0)
            {
                int numGetMore = numDisplayItem - rowCount;
                DataTable dtMerge = IncomeReport_DAO.getPrevIncomeReports(
                    dt.Rows[rowCount - 1]["MÃ ĐƠN"].ToString(), numGetMore);

                ViewModel.data.Merge(dtMerge);
            }

            //Tính toán để duy chuyển
            if (rowCount > numDisplayItem)
            {
                ViewModel.data.Rows.RemoveAt(0); // dòng cuối là dummy
                ViewModel.keyPrevBoundary = ViewModel.data.Rows[0]["MÃ ĐƠN"].ToString();
                ViewModel.keyNextBoundary = ViewModel.data.Rows[rowCount - 2]["MÃ ĐƠN"].ToString();
            }
            else if (rowCount > 0)
            {
                ViewModel.keyPrevBoundary = ViewModel.data.Rows[0]["MÃ ĐƠN"].ToString();
                ViewModel.keyNextBoundary = ViewModel.data.Rows[rowCount - 1]["MÃ ĐƠN"].ToString();
            }
            else // không tìm thấy thông tin nào trùng vào bộ lọc
            {
                ViewModel.isEmpty = true;
            }

            if (!ViewModel.isEmpty)
            {

                //Định dạng lai ngày tháng năm
                foreach (DataRow row in ViewModel.data.Rows)
                {
                    row["NGÀY HIỆU LỰC ĐƠN"] = Helper.convertToCorrectDateTime(row["NGÀY HIỆU LỰC ĐƠN"].ToString());
                }
            }

            return ViewModel;
        }
    }
}