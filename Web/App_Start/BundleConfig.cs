using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/bower_components/jquery/dist/jquery.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/bower_components/jquery-validation/dist/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js", // original ms package
                "~/Scripts/app/jquery.validate.globalize.datetime.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/cldr").Include(
                "~/bower_components/cldrjs/dist/cldr.js",
                "~/bower_components/cldrjs/dist/cldr/event.js",
                "~/bower_components/cldrjs/dist/cldr/supplemental.js",
                "~/bower_components/cldrjs/dist/cldr/unresolved.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                "~/bower_components/globalize/dist/globalize.js",
                "~/bower_components/globalize/dist/globalize/number.js",
                "~/bower_components/globalize/dist/globalize/*.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/bower_components/moment/min/moment-with-locales.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/bower_components/bootstrap/dist/js/bootstrap.js",
                "~/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                "~/bower_components/respond/respond.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.css",
                "~/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                "~/Content/font-awesome-4.6.1/css/font-awesome.css"
                //,"/Content/Theme/main.css"
                ));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                "~/Content/dist/css/AdminLte.css",
                "~/Content/dist/css/skins/_all-skins.min.css"
                ));

           bundles.Add(new ScriptBundle("~/bundles/app").Include(
                   "~/Content/plugins/slimScroll/jquery.slimscroll.js",
                   "~/Scripts/app/app.js"));

            bundles.Add(new ScriptBundle("~/Content/sitecss").Include(
                "~/Content/Site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/adminltejs").Include(
                "~/Scripts/AdminLTE/app.js"
                //"~/Scripts/plugins/jQuery/jQuery-2.2.0.min.js"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }   
}