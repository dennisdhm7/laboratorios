using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb_Hinojosa.Models;

namespace SistemaWeb_Hinojosa.Controllers
{
    public class CategoriaController : Controller
    {
        private Categoria objCategoria = new Categoria();

        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCategoria.Listar());
            }
            else { 
                return View(objCategoria.Buscar(criterio));
            }            
        }

        public ActionResult Ver(int id) {
            return View(objCategoria.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View( criterio == null ||  criterio == "" ? objCategoria.Listar() : objCategoria.Buscar(criterio));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Categoria() //un nuevo objeto
                : objCategoria.Obtener(id) //devuelvo el id a modificar
                );
        }

        public ActionResult Guardar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Guardar();
                return Redirect("~/Categoria/");
            }
            else 
            {
                return View("~/Views/Categoria/AgregarEditar.cshtml", categoria);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objCategoria.id_categ = id;
            objCategoria.Eliminar();
            return Redirect("~/Categoria/");
        }

    }
}