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
    public class AtencionsController : Controller
    {
        private ConsejeriaContext db = new ConsejeriaContext();

        // GET: Atencions
        public ActionResult Index()
        {
            var atenciones = db.Atenciones
                .Include(a => a.Docente)
                .Include(a => a.Estudiante);

            return View(atenciones.ToList());
        }

        // GET: Atencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Atencion atencion = db.Atenciones.Find(id);

            if (atencion == null)
                return HttpNotFound();

            return View(atencion);
        }

        // GET: Atencions/Create
        public ActionResult Create()
        {
            ViewBag.DocenteId = new SelectList(db.Docentes.Where(d => d.Activo == true)
                .Select(d => new {
                    d.Id,
                    NombreCompleto = d.Apellidos + " " + d.Nombres
                }),
                "Id", "NombreCompleto");

            ViewBag.EstudianteId = new SelectList(db.Estudiantes.Where(e => e.Activo == true)
                .Select(e => new {
                    e.Id,
                    NombreCompleto = e.Codigo + " - " + e.Apellidos + " " + e.Nombres
                }),
                "Id", "NombreCompleto");

            // Temas predefinidos
            ViewBag.Temas = new List<SelectListItem>
    {
        new SelectListItem { Value = "Plan de estudios", Text = "Consejería en asuntos relacionados con el plan de estudios" },
        new SelectListItem { Value = "Desarrollo profesional", Text = "Consejería en asuntos relacionados con el desarrollo profesional" },
        new SelectListItem { Value = "Inserción laboral", Text = "Consejería en asuntos relacionados con la inserción laboral" },
        new SelectListItem { Value = "Plan de tesis o Tesis", Text = "Asuntos Académicos del Proceso de Plan de Tesis o Tesis" },
        new SelectListItem { Value = "Otros", Text = "Otros" }
    };

            return View();
        }

        // POST: Atencions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Semestre,FechaAtencion,DocenteId,EstudianteId,Tema,Consulta,Descripcion,Evidencia")] Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                db.Atenciones.Add(atencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CargarCombos(atencion.DocenteId, atencion.EstudianteId);
            return View(atencion);
        }

        // GET: Atencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Atencion atencion = db.Atenciones.Find(id);

            if (atencion == null)
                return HttpNotFound();

            // Llenar DropDownList de Docentes
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "Nombres", atencion.DocenteId);

            // Llenar DropDownList de Estudiantes
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "Codigo", atencion.EstudianteId);

            // Llenar DropDownList de Temas
            ViewBag.Temas = new List<SelectListItem>
    {
        new SelectListItem { Value = "Plan de estudios", Text = "Consejería en asuntos relacionados con el plan de estudios" },
        new SelectListItem { Value = "Desarrollo profesional", Text = "Consejería en asuntos relacionados con el desarrollo profesional" },
        new SelectListItem { Value = "Inserción laboral", Text = "Consejería en asuntos relacionados con la inserción laboral" },
        new SelectListItem { Value = "Plan de tesis o Tesis", Text = "Asuntos Académicos del Proceso de Plan de Tesis o Tesis" },
        new SelectListItem { Value = "Otros", Text = "Otros" }
    };

            return View(atencion);
        }

        // POST: Atencions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atencion);
        }

        // GET: Atencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Atencion atencion = db.Atenciones.Find(id);

            if (atencion == null)
                return HttpNotFound();

            return View(atencion);
        }

        // POST: Atencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atencion atencion = db.Atenciones.Find(id);
            db.Atenciones.Remove(atencion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ------------------------------
        // MÉTODO CENTRALIZADO DE COMBOS
        // ------------------------------
        private void CargarCombos(int? docenteId = null, int? estudianteId = null)
        {
            ViewBag.DocenteId =
                new SelectList(
                    db.Docentes.Where(d => d.Activo == true)
                    .Select(d => new
                    {
                        d.Id,
                        NombreCompleto = d.Apellidos + " " + d.Nombres
                    }),
                "Id", "NombreCompleto", docenteId);

            ViewBag.EstudianteId =
                new SelectList(
                    db.Estudiantes.Where(e => e.Activo == true)
                    .Select(e => new
                    {
                        e.Id,
                        NombreCompleto = e.Codigo + " - " + e.Apellidos + " " + e.Nombres
                    }),
                "Id", "NombreCompleto", estudianteId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
