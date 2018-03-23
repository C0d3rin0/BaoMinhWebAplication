using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using BaoMinhWebApplication.Models.DAO;
using System.Web;

namespace BaoMinhWebApplication.Controllers
{
    public class AffiliateController : ApiController
    {
        // GET: api/Affiliate
        public string Get()
        {
            var Session = HttpContext.Current.Session; 
            if (Session["user"] == null)
                return "";

            return JsonConvert.SerializeObject(FilterData_DAO.layDanhSachChiNhanhh());
        }

        // GET: api/Affiliate/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Affiliate
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Affiliate/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Affiliate/5
        //public void Delete(int id)
        //{
        //}
    }
}
