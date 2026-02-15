using SobMedidaCortinas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobMedidaCortinas.Web.Controllers
{
    public class PersianasController : Controller
    {
        // GET: Persianas
        public ActionResult Index(string id)
        {
            var home = new HomeModel();

            var persiana = home.Persianas.SingleOrDefault(x => x.Id == id);

            return View(persiana);
        }
    }
}