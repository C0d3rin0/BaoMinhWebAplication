using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoMinhWebApplication.Models;
using BaoMinhWebApplication.Models.BUS;
using System.IO;
using System.Data;
using BaoMinhWebApplication.Models.DAO;
using Newtonsoft.Json;

namespace BaoMinhWebApplication.Controllers
{
    public class IncomeReportController : Controller
    {
        // GET: Search
        [HttpGet]
        public ActionResult Search()
        {
            if (!Session.isUserSession())
                return RedirectToAction("Login", "User", null);

            //else // Move prev

            /*Handle Table search*/
            return View();
        }

        //[HttpPost]
        //public string layNghiepVu()
        //{
        //    return JsonConvert.SerializeObject(IncomeReport_BUS.layNghiepVu());
        //}

        [HttpPost]
        public string Load()
        {
            if (!Session.isUserSession())
                return "";

            InitFilterIncomeReportViewModel ViewModel = new InitFilterIncomeReportViewModel();
            var DanhSachIdChiNhanh = ((TaiKhoan)Session["user"])
                .Nhom
                .SelectMany(g => g.NhomThuocChiNhanh)
                .Select(gg => gg.MaChiNhanh)
                .Distinct();

            Entities entities = new Entities();
            var DanhSachChiNhanh = entities
                .PQDONVI_
                .Where(u => DanhSachIdChiNhanh.Contains(u.id))
                .Select(uu => new
                {
                    uu.name,
                    value = uu.id,
                    label = uu.name + "[" + uu.id + "]"

            }).ToArray();

            ViewModel.DanhSachChiNhanh = DanhSachChiNhanh;
            

            //. ViewModel.DanhSachLoaiDaiLy = FilterData_DAO.layLoaiDaiLy();
            ViewModel.DanhSachNvXE = FilterData_DAO.layNghiepVuXe();
            ViewModel.DanhSachNvKT = FilterData_DAO.layNghiepVuKiThuat();
            ViewModel.DanhSachNvHH = FilterData_DAO.layNghiepVuHangHai();

            return JsonConvert.SerializeObject(ViewModel);
        }

        //[HttpPost]
        //public string layDanhSachPhongBanTheoTenHoacMa(string NoiDung)
        //{
        //if (!Session.isUserSession())
        //    return "";

        //    DataTable dt = FilterData_DAO.layDanhSachPhongBanTheoTenHoacMa(NoiDung);

        //    return JsonConvert.SerializeObject(FilterData_DAO.layDanhSachPhongBanTheoTenHoacMa(NoiDung));
        //}

        //[HttpPost]
        //public string layHoTenKhachHang(string NoiDung)
        //{
        //    //if (!Session.isUserSession())
        //    //    return "";

        //    DataTable dt = FilterData_DAO.layHoTenKhachHang(NoiDung);

        //    return JsonConvert.SerializeObject(FilterData_DAO.layHoTenKhachHang(NoiDung));
        //}

        //POST : Search
        [HttpPost]
        public string RemoteSearch(
            string keyPrevBoundary,
            string keyNextBoundary,
            FilterIncomeReportViewModel SearchViewModel,
            int numItemsPerPage = 20)
        {
            if (!Session.isUserSession())
                return "";

            /*Navigation*/
            IncomeReportRemoteSearchViewModel DataTableViewModel;
            //Parse JsonQuery into stuff


            //Default
            var authorizeGroups = ((TaiKhoan)Session["User"]).Nhom;

            if (!string.IsNullOrEmpty(keyNextBoundary) || 
                string.IsNullOrEmpty(keyPrevBoundary)) // Move next and default
            {
                DataTableViewModel = IncomeReport_BUS.getNextIncomeReports(keyNextBoundary, numItemsPerPage, SearchViewModel, authorizeGroups);
            }
            else
            {
                DataTableViewModel = IncomeReport_BUS.getPrevIncomeReports(keyPrevBoundary, numItemsPerPage);
            }

            //Serialize thành json
            string json = JsonConvert.SerializeObject(DataTableViewModel);
            return json;
        }

        //POST : ViewDetails/5
        [HttpPost]
        public string ViewDetails(string RLDGACCT)
        {
            if (!Session.isUserSession())
                return "";

            DataTable dt = IncomeReport_DAO.getDetails(RLDGACCT);

            //Serialize thành json
            string json = JsonConvert.SerializeObject(dt);
            return json;
        }

        //POST : ViewDetails/5
        [HttpPost]
        public string layMaDaiLy(string NoiDung)
        {
            if (!Session.isUserSession())
                return "";

            DataTable dt = FilterData_DAO.layMaDaiLy(NoiDung);

            //Serialize thành json
            string json = JsonConvert.SerializeObject(dt);
            return json;
        }

        //POST : ViewDetails/5


        //POST : DownExcel
        public void DownExcel(string JsonFilterQuery = "")
        {
            if (!Session.isUserSession())
                return;

            string myName = Server.UrlEncode("TruyVanDoanhThu_" + DateTime.Now.ToShortDateString() + ".xlsx");
            MemoryStream stream = (MemoryStream)IncomeReport_BUS.createExcel();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + myName);
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(stream.ToArray());
            Response.End();
        }
    }
}