using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoMinhWebApplication.Models
{
    public class UserSearchModel : SearchViewModel
    {
        public string keyPrevBoundary { get; set; }
        public string keyNextBoundary { get; set; }
        public AccountResultSearchViewModel[] data { get; set; }
    }

    public class AccountResultSearchViewModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool LaAdmin { get; set; }
        public bool State { get; set; }
    }

    public class FilterAccountViewModel
    {
        public FilterViewModel[] DanhSachChiNhanh { get; set; }
        public FilterViewModel[] DanhSachPhongBan { get; set; }
    }

    public class createUserViewModel:updateUserViewModel
    {
        public string MatKhau { get; set; }
        public string NhapLaiMatKhau { get; set; }
        
    }

    public class updateUserViewModel
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public int[] MaNhom { get; set; }

    }


    public class LoginViewModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class ResultViewModel
    {
        public ResultViewModel(string message, string header)
        {
            this.message = message;
            this.header = header;
        }

        public bool isShowModal {get;set;} = true;
        public string header { get; set; }
        public string message { get; set; }
    }
}