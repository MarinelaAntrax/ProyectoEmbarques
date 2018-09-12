using System.Web;
using System.Web.Optimization;

namespace ProyectoEmbarques
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
              "~/Scripts/kendo/2018.1.221/kendo.all.min.js",
              "~/Scripts/kendo/2018.1.221/kendo.timezones.min.js",
              "~/Scripts/kendo/2018.1.221/kendo.aspnetmvc.min.js",
              "~/Scripts/messages/kendo.messages.es-MX.min.js",
              "~/Scripts/cultures/kendo.culture.es-MX.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
               "~/Content/kendo/2018.1.221/kendo.common-bootstrap.min.css",
               "~/Content/kendo/2018.1.221/kendo.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/Site.css",
                     "~/Content/bae-styles.css",
                      "~/Content/font-awesome.min.css"));
        }
    }
}
