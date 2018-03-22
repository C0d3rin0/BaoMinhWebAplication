using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaoMinhWebApplication.Models;
using BaoMinhWebApplication.Models.BUS;
using BaoMinhWebApplication.Models.DAO;
using Newtonsoft.Json;
using System.Web;

namespace BaoMinhWebApplication.Controllers.Api
{
    public enum GetPaginationType
    {
        Next,
        Prev
    }

    public class UserController : ApiController
    {
        public string Get(int Id)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();

            var QueryResult = 
                entities
                .TaiKhoan
                .Where(p => p.id == Id)
                .Select(p => new
                    {
                        Username = p.TenDangNhap,
                        Fullname = p.Ten,
                        Id = p.id,
                        SelectedGroups = p.Nhom.Select(g => new
                        {
                            label = g.Ten,
                            Id = g.id
                        }),
                    })
                .First();

            return JsonConvert.SerializeObject(QueryResult);
        }

        // GET: api/User
        public string Get(
            string Email = null)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();
            var QueryResult = 
                entities
                    .TaiKhoan
                    .Where(p => p.TenDangNhap.Contains(Email))
                    .Select(p => new
                        {
                            Email = p.TenDangNhap,
                            Fullname = p.Ten,
                            Id = p.id
                        })
                    .Take(10)
                    .ToArray();

            return JsonConvert.SerializeObject(QueryResult);
        }

        public string Get(
            int numItemsPerPage,
            GetPaginationType GetPaginationType,
            int? Id = null,
            string keyBoundary = null
            )
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            if (Id != null)
            {
                var User = (new Entities()).TaiKhoan.Where(p => p.id == Id).Select(u => new {
                    Email = u.TenDangNhap,
                    Fullname = u.Ten,
                    State = u.TrangThai,
                    Id = u.id,
                    u.LaAdmin,
                });

                return JsonConvert.SerializeObject(
                    new { data = User }
                );
            }

            if(GetPaginationType == GetPaginationType.Next)

            return JsonConvert.SerializeObject(Account_BUS.getNext(
                keyBoundary, 
                numItemsPerPage));

            else

            return JsonConvert.SerializeObject(Account_BUS.getPrev(
               keyBoundary,
               numItemsPerPage));
        }



        // POST: api/User
        public string Post(createUserViewModel viewModel)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            string Error = ValidateViewModel(viewModel);

            if (Error == "")
            {
                if (string.IsNullOrEmpty(viewModel.MatKhau))
                    return JsonConvert.
                        SerializeObject(new ResultViewModel(
                            "Mật khẩu không được để trống",
                            "Đã xảy ra lỗi trong quá trình tạo tài khoản"));

                if (!Helper.KiemTraHopLeMatKhau(viewModel.MatKhau))
                    return JsonConvert.
                        SerializeObject(new ResultViewModel(
                            "Mật khẩu phải có kí tự viết hoa, tối thiểu 8 kí tự",
                            "Đã xảy ra lỗi trong quá trình tạo tài khoản"));

                if (string.IsNullOrEmpty(viewModel.MatKhau))
                    return JsonConvert.
                        SerializeObject(new ResultViewModel(
                            "Mật khẩu nhập lại không được để trống",
                            "Đã xảy ra lỗi trong quá trình tạo tài khoản"));

                if (!Authentication_DAO.TaoTaiKhoan(viewModel))
                    return JsonConvert.
                        SerializeObject(new ResultViewModel(
                            "Email của tài khoản này đã tồn tại rồi",
                            "Đã xảy ra lỗi trong quá trình tạo tài khoản"));

                
            }

            return Error;
        }

        //PUT: api/User/5
        public string Put(int id, updateUserViewModel viewModel)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            string Error = ValidateViewModel(viewModel);

            if (Error == "")
            {
                return JsonConvert.SerializeObject(User_DAO.update(id, viewModel));
            }

            return Error;
        }



        static string ValidateViewModel(updateUserViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.HoTen))
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Họ tên không được để trống",
                        "Đã xảy ra lỗi trong quá trình tạo tài khoản"));

            if (string.IsNullOrEmpty(viewModel.Email))
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Email không được để trống",
                        "Đã xảy ra lỗi trong quá trình tạo tài khoản"));



            try
            {
                var addr = new System.Net.Mail.MailAddress(viewModel.Email);
                if (addr.Address != viewModel.Email)
                    throw new Exception();
            }
            catch
            {
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Email không hợp lệ",
                        "Đã xảy ra lỗi trong quá trình tạo tài khoản"));
            }

            return "";
        }

        

        // DELETE: api/User/5
        public string Delete(int id)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();
            var User = entities.TaiKhoan.Where(u => u.id == id).First();
            User.TrangThai = false;
            entities.SaveChanges();

            return JsonConvert.SerializeObject(new {
                Username = User.TenDangNhap,
                Fullname = User.Ten,
                Id = User.id,
                State = User.TrangThai,
                User.LaAdmin
            });
        }
    }
}
