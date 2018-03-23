using System.Web;
using System.Web.Optimization;

namespace BaoMinhWebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Script load nếu đăng nhập
            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                "~/Content/js/jquery-{version}.js", // Top dependency
                "~/Content/js/bootstrap.bundle.js", // Bootstrap
                "~/Content/js/jquery.actual.js", // Dependency của share.js
                "~/Content/js/mdb.js", // 
                "~/Content/js/dist/share.js")); // Script navigation

            //Script load nếu cần validate
            bundles.Add(new ScriptBundle("~/js/jqueryval").Include(
                        "~/Content/js/jquery.validate*"));

            //Style mặc định
            bundles.Add(new StyleBundle("~/Content/DefaultStyle/").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/mdb.css",
                "~/Content/css/Site.css",
                "~/Content/css/fontawesome-all.css"));


            //Search User
            bundles.Add(new ScriptBundle("~/js/searchUser").Include(
                "~/Content/js/lodash.core.js",
                "~/Content/js/vue.js",
                "~/Content/js/vue-select.js",
                "~/Content/js/dist/loading.js",
                "~/Content/js/dist/select.js",
                "~/Content/js/dist/table.js",
                "~/Content/js/dist/AjaxSearch.js",
                "~/Content/js/dist/searchGroupByNameMixin.js",
                "~/Content/js/dist/editRowSearchMixin.js",
                "~/Content/js/dist/editRowSearchUser.js",
                "~/Content/js/dist/searchMixin.js",
                "~/Content/js/dist/searchUser.js"));

            bundles.Add(new ScriptBundle("~/js/searchGroup").Include(
                "~/Content/js/lodash.core.js",
                "~/Content/js/vue.js",
                "~/Content/js/vue-select.js",
                "~/Content/js/dist/loading.js",
                "~/Content/js/dist/select.js",
                "~/Content/js/dist/table.js",
                "~/Content/js/dist/AjaxSearch.js",
                "~/Content/js/dist/modal.js",
                "~/Content/js/dist/searchGroupByNameMixin.js",
                "~/Content/js/dist/addPermisionToGroupMixin.js",
                "~/Content/js/dist/searchUserByEmailMixin.js",
                "~/Content/js/dist/editRowSearchMixin.js",
                "~/Content/js/dist/editRowSearchGroup.js",
                "~/Content/js/dist/searchMixin.js",
                "~/Content/js/dist/searchGroup.js"));



            bundles.Add(new ScriptBundle("~/js/IncomeReport").Include(
                "~/Content/js/lodash.core.js",
                "~/Content/js/moment.js",
                "~/Content/js/vue.js",
                "~/Content/js/bootstrap-datepicker.js",
                "~/Content/js/vue-select.js",
                "~/Content/js/dist/loading.js",
                "~/Content/js/dist/select.js",
                "~/Content/js/dist/table.js",
                "~/Content/js/dist/inc.js"));




            bundles.Add(new StyleBundle("~/css/IncomeReport").Include(
                "~/Content/css/bootstrap-datepicker.css",
                "~/Content/css/vue-treeselect.css"));

            //Login
            bundles.Add(new ScriptBundle("~/js/Login").Include(
                "~/Content/js/vue.js",
                "~/Content/js/dist/loading.js",
                "~/Content/js/dist/login.js"));

            //
            bundles.Add(new ScriptBundle("~/js/createUser").Include(
                "~/Content/js/vue.js",
                "~/Content/js/lodash.core.js",
                "~/Content/js/dist/loading.js",
                "~/Content/js/vue-select.js",
                "~/Content/js/dist/AjaxCreate.js",
                "~/Content/js/dist/AjaxSearch.js",
                "~/Content/js/dist/createUser.js"));

            bundles.Add(new ScriptBundle("~/js/createGroup").Include(
                "~/Content/js/lodash.core.js",
                "~/Content/js/vue.js",
                "~/Content/js/dist/modal.js",
                "~/Content/js/dist/table.js",
                "~/Content/js/dist/loading.js",
                "~/Content/js/vue-select.js",
                "~/Content/js/dist/AjaxCreate.js",
                "~/Content/js/dist/AjaxSearch.js",
                "~/Content/js/dist/createGroup.js"));

            //Enable Bundles and Minificiation
            //BundleTable.EnableOptimizations = true;
        }
    }
}
