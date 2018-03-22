using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoMinhWebApplication.Models
{
    public class AffiliationPermisionModel
    {
        public int id { get; set; }
        public int[] downPermision { get; set; }
        public int[] searchPermision { get; set; }
    }

    public class _AffiliationPermisionModel
    {
        public int Id { get; set; }
        public int[] downPermision { get; set; }
        public int[] searchPermision { get; set; }
    }

    public class GroupApiModel
    {
        public string name { get; set; }
        public int[] usersId { get; set; }
        public AffiliationPermisionModel[] affiliationsWithPermision { get; set; }
    }

    public class GroupUpdateApiModel
    {
        public string name { get; set; }
        public int Id { get; set; }
        public int[] SelectedUsersId { get; set; }
        public _AffiliationPermisionModel   [] affiliationWithPermision { get; set; }
    }

    public class ConventionSearchModel : SearchViewModel
    {
        public string keyPrevBoundary { get; set; }
        public string keyNextBoundary { get; set; }
        public dynamic[] data { get; set; }
    }

}