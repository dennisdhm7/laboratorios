using PracticaCalifica_ChristianHinojosa.Filters;
using PracticaCalifica_ChristianHinojosa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PracticaCalifica_ChristianHinojosa.Controllers
{
    [ValidarSesion]
    public class DocentesController : Controller
    {
        private ConsejeriaContext db = new ConsejeriaContext();

        // GET: Docentes
        public ActionResult Index()
        {
            return View(db.Docentes.ToList());
        }
        public ActionResult Dashboard()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Auth");

            // Obtener docente logueado
            var correo = Session["usuario"].ToString();
            var docente = db.Docentes.FirstOrDefault(d => d.CorreoCorporativo == correo);

            if (docente == null)
                return RedirectToAction("Login", "Auth");

            // Atenciones que el docente ha registrado
            var misAtenciones = db.Atenciones
                .Where(a => a.DocenteId == docente.Id)
                .Include(a => a.Estudiante)
                .ToList();

            ViewBag.NombreDocente = docente.Nombres + " " + docente.Apellidos;

            return View(misAtenciones);
        }
        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,Apellidos,CorreoCorporativo,Activo")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Docentes.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docente);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,Apellidos,CorreoCorporativo,Activo")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docentes.Find(id);
            db.Docentes.Remove(docente);
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
