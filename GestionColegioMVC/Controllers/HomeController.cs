using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionColegioMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A paxina de descripcion da aplicacion.";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "As nosas formas de contacto.";

            return View();
        }

        public ActionResult VistaTesteo()
        {
            return View();
        }
    }
}