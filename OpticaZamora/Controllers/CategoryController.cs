using OpticaZamora.Interface;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoriaService CategoriaService;
        private ICategoriaValidation CategoriaValidation;
        public CategoryController(ICategoriaService CategoriaService, ICategoriaValidation CategoriaValidation)
        {
            this.CategoriaService = CategoriaService;
            this.CategoriaValidation = CategoriaValidation;
        }
        // GET: Category
        [Authorize] ///LISTA CAREGORIA
        public ActionResult List(string criterio)
        {
            var categorias = CategoriaService.GetRetornarListaCategoria();
            return View("List", categorias);
        }
        [Authorize]
        [HttpGet] ///GUARDAR CAREGORIA
        public ViewResult Save()
        {
            return View("Save", new Categoria());
        }
        [Authorize]
        [HttpPost] ///GUARDAR CAREGORIA
        public ActionResult Save(Categoria categoria)
        {
            CategoriaValidation.Validate(categoria, ModelState);
            if (!ModelState.IsValid)
                return View("Save", categoria);

            CategoriaService.AddCategoria(categoria);
            return RedirectToAction("List");
        }
        [Authorize] ///EDITAR CAREGORIA
        public ViewResult Edit(string Edit_Category)
        {
            var categoria = CategoriaService.CategoriaModificar(Edit_Category);
            return View("Edit", categoria);
        }
        [Authorize] ///ACTUALIZAR CAREGORIA
        public ActionResult Update(Categoria categoria)
        {
            CategoriaValidation.ValidateUpdate(categoria, ModelState);
            if (!ModelState.IsValid)
                return View("Edit", categoria);

            CategoriaService.UpdateCategoria(categoria);
            return RedirectToAction("List");
        }
    }
}