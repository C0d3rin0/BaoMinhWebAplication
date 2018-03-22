using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace BaoMinhWebApplication.Models
{
    public class IncomeReportRemoteSearchViewModel : SearchViewModel
    {
        public string keyPrevBoundary { get; set; }
        public string keyNextBoundary { get; set; }
        public DataTable data { get; set; } = new DataTable();
    }

    public class NghiepVuViewModel
    {
        public string[] PREMCL { get; set; }
        public string[] RSKTYP { get; set; }
    }

    //public class NoiDungNV
    //{
    //    public string id { get; set; }
    //    public string label { get; set; }
    //}

    //public class NghiepVuViewModel
    //{
    //    public string id { get; set; }
    //    public string label { get; set; }
    //    public DataTable children { get; set; }
    //}

    public class FilterIncomeReportViewModel
    {
        public FilterViewModel[] DanhSachChiNhanh { get; set; }
        public FilterViewModel[] DanhSachPhongBan { get; set; }
        public string HoTenKhachHang { get; set; }
        public FilterViewModel[] DanhSachMaDaiLy { get; set; }
        public FilterViewModel[] DanhSachLoaiDaiLy { get; set; }
        public NghiepVuViewModel DanhSachNghiepVu { get; set; }
        public string NgayHieuLucTu { get; set; }
        public string NgayHieuLucDen { get; set; }
    }

    public class InitFilterIncomeReportViewModel
    {
        public object[] DanhSachChiNhanh { get; set; }
        public DataTable DanhSachLoaiDaiLy { get; set; }
        public DataTable DanhSachNvHH { get; set; }
        public DataTable DanhSachNvKT { get; set; }
        public DataTable DanhSachNvXE { get; set; }
    }

    public class TenKhachHang
    {
        public string label { get; set; }
    }

}