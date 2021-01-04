using System.Web;
using System.Web.Optimization;

namespace GestionColegioMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery-ajax").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery.unobtrusive-ajax.js")); //para traballar con unobtrusive Ajax

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));//agrego jquery-ui por utilidades tan interesantes como autocompletar ou Datepicker

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/themes/base/autocomplete.css")); //estos bundles de paquetes web dinamicos carganse o cargar a web, e moi de axuda
            //autocomplete sera de moita utilidade para as listas de estudiantes por cursos e mostralos rapidamente
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include("~/Content/themes/base/all.css", "~/Content/themes/base/datepicker.css"));
        }
    }
}
