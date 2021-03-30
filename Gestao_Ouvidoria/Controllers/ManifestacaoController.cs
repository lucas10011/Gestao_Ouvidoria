using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestao_Ouvidoria.Models;

namespace Gestao_Ouvidoria.Controllers
{
    public class ManifestacaoController : Controller
    {
        private OuvidoriaContext db = new OuvidoriaContext();

        // GET: Manifestacao
        public ActionResult Index()
        {
            var manifestacoes = db.Manifestacao.Include(m => m.Perfil);
            ViewBag.Respondida = db.Manifestacao.Where(a => a.Status == TipoStatus.Respondida).ToList().Count;
            ViewBag.Vencida = db.Manifestacao.Where(a => a.Status == TipoStatus.Vencida).ToList().Count;
            ViewBag.Pendente = db.Manifestacao.Where(a => a.Status == TipoStatus.Pendente).ToList().Count;
            ViewBag.Excluida = db.Manifestacao.Where(a => a.Status == TipoStatus.Excluida).ToList().Count;
            ViewBag.Total = db.Manifestacao.ToList().Count;
            return View(manifestacoes.ToList());
        }

        // GET: Manifestacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            Manifestacao manifestacao = db.Manifestacao.Find(id);
           
            if (manifestacao == null)
            {
                return HttpNotFound();
            }
            return View(manifestacao);
        }

        // GET: Manifestacao/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(db.Perfil, "Id", "Nome");
            return View();
        }

        // POST: Manifestacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Campus,Curso,TipoSolicitacao,Setor,Assunto,ManifestacaoConteudo,Status,IdPerfil")] Manifestacao manifestacao)
        {
            if (ModelState.IsValid)
            {
                manifestacao.Created = DateTime.Now;
                manifestacao.Modified = DateTime.Now;
                db.Manifestacao.Add(manifestacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(db.Perfil, "Id", "Nome", manifestacao.IdPerfil);
            return View(manifestacao);
        }


        // POST: Manifestacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manifestacao manifestacao = db.Manifestacao.Find(id);
            manifestacao.Status = TipoStatus.Excluida;
            db.Entry(manifestacao).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
