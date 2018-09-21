using System.Web;
using System.Web.Optimization;

namespace AlphasoftWebsite.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(                       
                "~/Content/AdminLTE/bower_components/jquery/dist/jquery.min.js",
                "~/Content/AdminLTE/bower_components/jquery-ui/jquery-ui.min.js",
                "~/Content/AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/AdminLTE/bower_components/select2/dist/js/select2.full.min.js",
                "~/Content/AdminLTE/bower_components/datatables.net/js/jquery.dataTables.min.js",
                "~/Content/AdminLTE/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                "~/Content/AdminLTE/bower_components/raphael/raphael.min.js",
                "~/Content/AdminLTE/bower_components/morris.js/morris.min.js",
                "~/Content/AdminLTE/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js",
                "~/Content/AdminLTE/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Content/AdminLTE/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/Content/AdminLTE/bower_components/jquery-knob/dist/jquery.knob.min.js",
                "~/Content/AdminLTE/bower_components/moment/min/moment.min.js",
                "~/Content/AdminLTE/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/AdminLTE/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                "~/Content/AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                "~/Content/AdminLTE/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/AdminLTE/bower_components/fastclick/lib/fastclick.js",
                "~/Content/AdminLTE/dist/js/adminlte.min.js",
                "~/Content/AdminLTE/dist/js/pages/dashboard.js",
                "~/Content/AdminLTE/dist/js/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/AdminLTE/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/Content/AdminLTE/bower_components/Ionicons/css/ionicons.min.css",
                      "~/Content/AdminLTE/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                      "~/Content/AdminLTE/dist/css/AdminLTE.min.css",
                      "~/Content/AdminLTE/dist/css/skins/_all-skins.min.css",
                      "~/Content/AdminLTE/bower_components/morris.js/morris.css",
                      "~/Content/AdminLTE/bower_components/jvectormap/jquery-jvectormap.css",
                      "~/Content/AdminLTE/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                      "~/Content/AdminLTE/bower_components/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Content/AdminLTE/bower_components/select2/dist/css/select2.min.css",
                      "~/Content/AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));

            bundles.Add(new StyleBundle("~/Content/Frontend/css").Include(
                "~/Content/Frontend/css/bootstrap.min.css",
                "~/Content/Frontend/css/font-awesome.min.css",
                "~/Content/Frontend/plugins/swiper/swiper.min.css",
                "~/Content/Frontend/plugins/magnific-popup/magnific-popup.min.css",
                "~/Content/Frontend/plugins/color-switcher/color-switcher.css",
                "~/Content/Frontend/css/style.css",
                "~/Content/Frontend/css/responsive.css",
                "~/Content/Frontend/css/colors/theme-color-1.css",
                "~/Content/Frontend/css/custom.css"               
                ));

            bundles.Add(new ScriptBundle("~/Content/Frontend/js").Include(
                "~/Content/Frontend/js/jquery-3.3.1.min.js",
                "~/Content/Frontend/js/bootstrap.bundle.min.js",
                "~/Content/Frontend/plugins/waypoints/jquery.waypoints.min.js",
                "~/Content/Frontend/plugins/waypoints/sticky.min.js",
                "~/Content/Frontend/plugins/swiper/swiper.min.js",
                "~/Content/Frontend/plugins/magnific-popup/jquery.magnific-popup.min.js",
                "~/Content/Frontend/plugins/parsley/parsley.min.js",
                "~/Content/Frontend/plugins/retinajs/retina.min.js",
                "~/Content/Frontend/plugins/isotope/isotope.pkgd.min.js",
                "~/Content/Frontend/js/menu.min.js",
                "~/Content/Frontend/js/scripts.js",
                "~/Content/Frontend/js/custom.js"
                ));
        }
    }
}
