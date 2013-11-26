using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/login").Include(
                        "~/Content/bootstrap/css/bootstrap.css",
                        "~/Content/css/login.css",
                        "~/Content/css/helper.css"));

            bundles.Add(new StyleBundle("~/Content/lib").Include(
                        "~/Content/bootstrap/css/bootstrap.css",
                        "~/Content/select2-3.4.3/select2.css",
                        "~/Content/font-awesome-4.0.1/css/font-awesome.css",
                        "~/Content/datepicker/bootstrap-datepicker.css"));

            bundles.Add(new StyleBundle("~/Content/app").Include(
                        "~/Content/css/navigation.css",
                        "~/Content/css/expences.css",
                        "~/Content/css/stats.css",
                        "~/Content/css/helper.css"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Content/bootstrap/js/bootstrap.js",
                        "~/Content/js/lib/jquery-{version}.js",
                        "~/Content/js/lib/jquery.unobtrusive*",
                        "~/Content/js/lib/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Content/js/lib/jquery-1.7.1.js",
                        "~/Content/bootstrap/js/bootstrap.js",
                        "~/Content/js/lib/angular-*",
                        "~/Content/js/lib/ui-*",
                        "~/Content/select2-3.4.3/select2.js",
                        "~/Content/datepicker/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Content/js/app/controllers/*.js",
                        "~/Content/js/app/app.js",
                        "~/Content/js/app/controllers.js",
                        "~/Content/js/app/directives.js",
                        "~/Content/js/app/filters.js",
                        "~/Content/js/app/services.js",
                        "~/Content/js/app/animations.js"));

            #region old

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/project").Include(
                        "~/Content/select2-3.4.3/select2.js",
                        "~/Content/datepicker/js/bootstrap-datepicker.js",
                        "~/Content/js/security.js",
                        "~/Content/js/models/shared/navigation.mvvm.js",
                        "~/Content/js/models/expences/new-expence.mvvm.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/lib/jquery.unobtrusive*",
                        "~/Content/js/lib/jquery.validate*"));

            #endregion

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}