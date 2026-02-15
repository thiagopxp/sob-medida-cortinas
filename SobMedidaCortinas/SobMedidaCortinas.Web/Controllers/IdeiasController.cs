using SobMedidaCortinas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobMedidaCortinas.Web.Controllers
{
    public class IdeiasController : Controller
    {
        // GET: Ideias
        public ActionResult Index(string id)
        {
            var home = new HomeModel();

            var ideia = home.Ideias.SingleOrDefault(x => x.Id == id);

            return View(ideia);
        }
    }
}