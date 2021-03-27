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
            var manifestacoes = db.Manifestacoes.Include(m => m.Perfil);
            return View(manifestacoes.ToList());
        }

        // GET: Manifestacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifestacao manifestacao = db.Manifestacoes.Find(id);
            if (manifestacao == null)
            {
                return HttpNotFound();
            }
            return View(manifestacao);
        }

        // GET: Manifestacao/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(db.Perfils, "Id", "Nome");
            return View();
        }

        // POST: Manifestacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Campus,Curso,TipoSolicitacao,Setor,Assunto,ManifestacaoConteudo,Created,Modified,Status,IdPerfil")] Manifestacao manifestacao)
        {
            if (ModelState.IsValid)
            {
                db.Manifestacoes.Add(manifestacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(db.Perfils, "Id", "Nome", manifestacao.IdPerfil);
            return View(manifestacao);
        }

        // GET: Manifestacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifestacao manifestacao = db.Manifestacoes.Find(id);
            if (manifestacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPerfil = new SelectList(db.Perfils, "Id", "Nome", manifestacao.IdPerfil);
            return View(manifestacao);
        }

        // POST: Manifestacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Campus,Curso,TipoSolicitacao,Setor,Assunto,ManifestacaoConteudo,Created,Modified,Status,IdPerfil")] Manifestacao manifestacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manifestacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPerfil = new SelectList(db.Perfils, "Id", "Nome", manifestacao.IdPerfil);
            return View(manifestacao);
        }

        // GET: Manifestacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifestacao manifestacao = db.Manifestacoes.Find(id);
            if (manifestacao == null)
            {
                return HttpNotFound();
            }
            return View(manifestacao);
        }

        // POST: Manifestacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manifestacao manifestacao = db.Manifestacoes.Find(id);
            db.Manifestacoes.Remove(manifestacao);
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
