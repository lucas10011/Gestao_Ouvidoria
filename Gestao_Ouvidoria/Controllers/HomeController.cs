using Gestao_Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestao_Ouvidoria.Controllers
{
    public class HomeController : Controller
    {
        private OuvidoriaContext db = new OuvidoriaContext();
        public ActionResult Index()
        {
            ViewBag.Respondida = db.Manifestacao.Where(a => a.Status == TipoStatus.Respondida).ToList().Count;
            ViewBag.Vencida = db.Manifestacao.Where(a => a.Status == TipoStatus.Vencida).ToList().Count;
            ViewBag.Pendente = db.Manifestacao.Where(a => a.Status == TipoStatus.Pendente).ToList().Count;
            ViewBag.Excluida = db.Manifestacao.Where(a => a.Status == TipoStatus.Excluida).ToList().Count;
            ViewBag.Total = db.Manifestacao.ToList().Count;
            return View(db.Manifestacao.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




    }

}