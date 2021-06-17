using System.Web;
using System.Web.Optimization;

namespace DemoProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region Log in
            bundles.Add(new ScriptBundle("~/scripts/loginindex").Include(
                "~/Content/Js/Login/login.js"));

            bundles.Add(new StyleBundle("~/styles/loginindex").Include(
                      "~/Content/Css/Login/login.css"
                     ));
            #endregion
            #region Error Page
            bundles.Add(new StyleBundle("~/styles/errorpage").Include(
                      "~/Content/Css/Login/errorpage.css"
                     ));
            #endregion
            #region Success Page
            bundles.Add(new StyleBundle("~/styles/successpage").Include(
                      "~/Content/Css/Login/successpage.css"
                     ));
            #endregion
        }
    }
}
