using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestao_Ouvidoria.Models;

namespace Gestao_Ouvidoria.Controllers
{
    public class RespostaManifestacaoController : Controller
    {
        private OuvidoriaContext db = new OuvidoriaContext();

        // GET: RespostaManifestacao
        public ActionResult Index()
        {
            var respostaManifestacao = db.RespostaManifestacao.Include(r => r.Manifestacao);
            return View(respostaManifestacao.ToList());
        }

        // GET: RespostaManifestacao/Create/5
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifestacao manifestacao = db.Manifestacao.Find(id);
            ViewBag.Manifestacao = manifestacao;

            if (manifestacao == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdManifestacao = new SelectList(db.Manifestacao, "Id", "Assunto", id);

           
            return View();
        }


        // POST: RespostaManifestacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RespostaManifestacao respostaManifestacao, HttpPostedFileBase file)
        {
            Manifestacao manifestacao = db.Manifestacao.Find(respostaManifestacao.IdManifestacao);
            ViewBag.Manifestacao = manifestacao;
            ViewBag.IdManifestacao = new SelectList(db.Manifestacao, "Id", "Assunto", respostaManifestacao.IdManifestacao);

            if (ModelState.IsValid)
            {

                if (file.ContentLength > 0)
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Imgs"),
                           Path.GetFileName(file.FileName));
                        respostaManifestacao.Arquivo = path;
                        file.SaveAs(path);

                        ViewBag.Message = "Your message for success";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                manifestacao.Status = TipoStatus.Respondida;
                db.Entry(manifestacao).State = EntityState.Modified;
                db.RespostaManifestacao.Add(respostaManifestacao);
                db.SaveChanges();

                return RedirectToAction("Encaminhar", new { id = manifestacao.Id });
            }

            ViewBag.Message = "ERROR";
            return View(respostaManifestacao);
        }


        // GET: RespostaManifestacao/Encaminhar/5
        public ActionResult Encaminhar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
          
            Manifestacao manifestacao = db.Manifestacao.Find(id);
            ViewBag.Manifestacao = manifestacao;
            RespostaManifestacao respostaManifestacao = db.RespostaManifestacao.FirstOrDefault(e => e.IdManifestacao == manifestacao.Id);
            ViewBag.RespostaManifestacao = respostaManifestacao;


            List<Setor> setores = Enum.GetValues(typeof(Setor)).Cast<Setor>().ToList();
            ViewBag.setores = new SelectList(setores);

            if (manifestacao == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        // GET: RespostaManifestacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespostaManifestacao respostaManifestacao = db.RespostaManifestacao.Find(id);
            if (respostaManifestacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdManifestacao = new SelectList(db.Manifestacao, "Id", "Assunto", respostaManifestacao.IdManifestacao);
            return View(respostaManifestacao);
        }

        // POST: RespostaManifestacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ManifestacaoResposta,Arquivo,IdManifestacao")] RespostaManifestacao respostaManifestacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respostaManifestacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdManifestacao = new SelectList(db.Manifestacao, "Id", "Assunto", respostaManifestacao.IdManifestacao);
            return View(respostaManifestacao);
        }

        // GET: RespostaManifestacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RespostaManifestacao respostaManifestacao = db.RespostaManifestacao.Find(id);
            if (respostaManifestacao == null)
            {
                return HttpNotFound();
            }
            return View(respostaManifestacao);
        }

        // POST: RespostaManifestacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RespostaManifestacao respostaManifestacao = db.RespostaManifestacao.Find(id);
            db.RespostaManifestacao.Remove(respostaManifestacao);
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
