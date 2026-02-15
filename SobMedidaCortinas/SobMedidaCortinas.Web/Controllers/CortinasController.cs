using Newtonsoft.Json;
using SobMedidaCortinas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SobMedidaCortinas.Web.Controllers
{
    public class CortinasController : Controller
    {
        // GET: Cortinas
        public ActionResult Index(string id)
        {

            var home = new HomeModel();

            var cortina = home.Cortinas.SingleOrDefault(x => x.Id == id);

            return View(cortina);
        }
    }
}