using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using BaoMinhWebApplication.Models;
using BaoMinhWebApplication.Models.DAO;
using BaoMinhWebApplication.Models.BUS;
using Newtonsoft.Json;
using System.Linq;

namespace BaoMinhWebApplication.Controllers
{
    public static class UserExtendSession
    {
        public static bool isAdminSession(this HttpSessionStateBase Session)
        {
            return !(!Session.isUserSession() ||
                (Session["User"] as TaiKhoan).LaAdmin == false);
        }

        public static bool isUserSession(this HttpSessionStateBase Session)
        {
            return !(Session["user"]==null || (Session["User"] as TaiKhoan).TrangThai == false);
        }
    }

    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            if (!Session.isAdminSession())
                return RedirectToAction("Index", "Home", null);

            return View();
        }

        //
        //GET : AccountIndex
        public ActionResult Create()
        {

            if (!Session.isAdminSession())
                return RedirectToAction("Index", "Home", null);

            return View();
        }

        [HttpPost]
        public string setAdmin(int Id)
        {

            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();
            TaiKhoan User = getUser(Id,entities);
            User.LaAdmin = true;
            entities.SaveChanges();

            return JsonConvert.SerializeObject(new
            {
                Username = User.TenDangNhap,
                Fullname = User.Ten,
                Id = User.id,
                State = User.TrangThai,
                User.LaAdmin
            });
        }

        [HttpPost]
        public string getCurrentUserId()
        {
            if (!Session.isUserSession())
                return "";

            else return ((TaiKhoan)Session["User"]).id.ToString();
        }

        [HttpPost]
        public string unsetAdmin(int Id)
        {

            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();
            TaiKhoan User = getUser(Id, entities);
            User.LaAdmin = false;
            entities.SaveChanges();

            return JsonConvert.SerializeObject(new
            {
                Username = User.TenDangNhap,
                Fullname = User.Ten,
                Id = User.id,
                State = User.TrangThai,
                User.LaAdmin
            });
        }

        public TaiKhoan getUser(int Id,Entities entities)
        {
            return entities.TaiKhoan.Where(u => u.id == Id).First();

        }

        



        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login", "User", null);
        }
        //
        // GET: /Account/Login
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public string Undelete(int id)
        {

            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();
            var User = entities.TaiKhoan.Where(u => u.id == id).First();
            User.TrangThai = true;
            entities.SaveChanges();

            return JsonConvert.SerializeObject(new
            {
                Username = User.TenDangNhap,
                Fullname = User.Ten,
                Id = User.id,
                State = User.TrangThai,
                User.LaAdmin
            });
        }

        //
        // POST: /Account/Register
        [HttpPost]
        public string Login(LoginViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.email))
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Email không được để trống", 
                        "Đã xảy ra lỗi trong quá trình đăng nhập"));

            if (string.IsNullOrEmpty(viewModel.password))
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Password không được để trống",
                        "Đã xảy ra lỗi trong quá trình đăng nhập"));

            try
            {
                var addr = new System.Net.Mail.MailAddress(viewModel.email);
                if (addr.Address != viewModel.email)
                    throw new System.Exception();
            }
            catch
            {
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Email không hợp lệ",
                        "Đã xảy ra lỗi trong quá trình đăng nhập"));
            }

            var TaiKhoan = Authentication_DAO.layTaiKhoan(viewModel.email, viewModel.password);
            if (TaiKhoan == null)
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Nhập sai tên đăng nhập hoặc mật khẩu",
                        "Đã xảy ra lỗi trong quá trình đăng nhập"));
            else if (TaiKhoan.TrangThai==false)
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Tài khoản này đã bị vô hiệu hóa",
                        "Đã xảy ra lỗi trong quá trình đăng nhập"));
            else
                Session.Add("User", TaiKhoan);

            return "";
        }
    }
}