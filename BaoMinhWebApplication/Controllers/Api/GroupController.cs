using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BaoMinhWebApplication.Models;
using BaoMinhWebApplication.Models.BUS;
using BaoMinhWebApplication.Models.DAO;
using Newtonsoft.Json;

namespace BaoMinhWebApplication.Controllers.Api
{
    enum Permision
    {
        Vehicle,
        Marine,
        Rest,
    }

    public static class UserExtendSession
    {
        public static bool isAdminSession(this System.Web.SessionState.HttpSessionState Session)
        {
            return !(!Session.isUserSession() ||
                (Session["User"] as TaiKhoan).LaAdmin == false);
        }

        public static bool isUserSession(this System.Web.SessionState.HttpSessionState Session)
        {
            return Session["user"] != null && (Session["User"] as TaiKhoan).TrangThai == true;
        }
    }

    public class GroupController : ApiController
    {
        // GET: api/Group
        public string Get(string name)
        {
            var Session = HttpContext.Current.Session;

            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();
            var debug = entities
                .Nhoms
                .Where(p => p.Ten.Contains(name)).Select(p => new
            {
                label = p.Ten,
                p.id
            }).ToArray();

            return JsonConvert.SerializeObject(debug);
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
                var Group = (new Entities()).Nhoms.Where(p => p.id == Id).Select(u => new {
                    Name = u.Ten,
                    Id = u.Ten,
                    State = u.TrangThai
                });

                return JsonConvert.SerializeObject(
                    new { data = User }
                );
            }

            if (GetPaginationType == GetPaginationType.Next)

                return JsonConvert.SerializeObject(Group_BUS.getNext(
                    keyBoundary,
                    numItemsPerPage));

            else

                return JsonConvert.SerializeObject(Group_BUS.getNext(
                   keyBoundary,
                   numItemsPerPage));
        }


        //// GET: api/Group/5
        public string Get(int id)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            Entities entities = new Entities();

            var QueryResult =
                entities
                .Nhoms
                .Where(p => p.id == id)
                .Select(p => new
                {
                    name = p.Ten,
                    Id = p.id,
                    SelectedUsers = p.TaiKhoan.Select(u=>new
                    {
                        Email = u.TenDangNhap,
                        Fullname = u.Ten,
                        Id = u.id,
                    }),
                    affiliationWithPermision = p.NhomThuocChiNhanh.Select(af => new
                    {

                            Label = af.PQDONVI_.name,
                            Id = af.PQDONVI_.id,
                            searchPermision = af.QuyenXem_NhomThuocChiNhanh.Select(search=>search.Quyen),
                            downPermision = af.QuyenTai_NhomThuocChiNhanh.Select(down=>down.Quyen)
                        
                    })
                })
                .First();

            return JsonConvert.SerializeObject(QueryResult);
        }


        // POST: api/Group
        public string Post(GroupApiModel ViewModel)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            if (string.IsNullOrEmpty(ViewModel.name))
            {
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Tên nhóm tài khoản không được bỏ trống",
                        "Đã xảy ra lỗi trong quá trình tạo nhóm tài khoản"));
            }


            Group_DAO.create(ViewModel);
            return "";
        }

        // PUT: api/Group/5
        public string Put(GroupUpdateApiModel ViewModel)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return "";

            if (string.IsNullOrEmpty(ViewModel.name))
            {
                return JsonConvert.
                    SerializeObject(new ResultViewModel(
                        "Tên nhóm tài khoản không được bỏ trống",
                        "Đã xảy ra lỗi trong quá trình tạo nhóm tài khoản"));
            }

            Group_DAO.update(ViewModel);
            return "";
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            var Session = HttpContext.Current.Session;
            if (!Session.isAdminSession())
                return;

            Entities entities = new Entities();
            var group = entities.Nhoms.Where(u => u.id == id).First();
            group.TrangThai = false;
            entities.SaveChanges();
        }
    }
}
