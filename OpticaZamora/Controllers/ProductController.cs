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
    public class ProductController : Controller
    {
       
        private IProdcutoService ProductoService;
        private IProdcutoValidation ProdcutoValidation;
        private ICategoriaService CategoriaService;
        public ProductController(IProdcutoService ProductoService, IProdcutoValidation ProdcutoValidation, ICategoriaService CategoriaService)
        {
            this.ProductoService = ProductoService;
            this.ProdcutoValidation = ProdcutoValidation;
            this.CategoriaService = CategoriaService;
        }
        // GET: Product
        [Authorize] ///LISTA DE PRODUCTOS
        public ActionResult List(string criterio)
        {
            var producto = ProductoService.GetRetornarListaProducto(criterio);
            return View("List", producto);
        }
        [Authorize]
        [HttpGet] ///GUARDAR PRODUCTO
        public ViewResult Save()
        {
            ListaDeCaregorias();
            return View("Save", new Producto());
        }
        [Authorize]
        [HttpPost] ///GUARDAR PRODUCTO
        public ActionResult Save(Producto producto)
        {
            ListaDeCaregorias();
            ProdcutoValidation.Validate(producto, ModelState);
            if (!ModelState.IsValid)
                return View("Save", producto);

            ProductoService.AddProducto(producto);
            return RedirectToAction("List");
        }
        [Authorize] ///EDITAR PRODUCTO
        public ViewResult Edit(string Product_Edit)
        {
            ListaDeCaregorias();
            var producto = ProductoService.ProductoModificar(Product_Edit);
            return View("Edit", producto);
        }
        [Authorize] ///ACTUALIZAR PRODUCTO
        public ActionResult Update(Producto producto)
        {
            ListaDeCaregorias();

            ProdcutoValidation.ValidateUpdate(producto, ModelState);
            if (!ModelState.IsValid)
                return View("Edit", producto);

            ProductoService.UpdateProducto(producto);
            return RedirectToAction("List");
        }
        ///LISTA DE CATEGORIAS
        public void ListaDeCaregorias()
        {
            var categoria = CategoriaService.GetRetornarListaCategoria();
            ViewBag.categoria = new SelectList(categoria, "IdCategoria", "Nombre");
        }
    }
}