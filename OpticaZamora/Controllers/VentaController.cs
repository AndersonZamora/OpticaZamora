using OpticaZamora.DB;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OpticaZamora.Interface;

namespace OpticaZamora.Controllers
{
    public class VentaController : Controller
    {
        private OpticaContext context; 
        private IPacienteService PacienteService;
        private IVentaService ventaService;
        private IExpedienteService expedienteService;
        public VentaController(IPacienteService PacienteService, IVentaService ventaService, IExpedienteService expedienteService)
        {
            this.PacienteService = PacienteService;
            this.ventaService = ventaService;
            this.expedienteService = expedienteService;
            context = new OpticaContext();
        }
        [HttpGet]
        [Authorize]
        public ViewResult SalesModule()
        {
            ///CLIENTE
            var cliente = context.Pacientes.ToList();
            ViewBag.paciente = cliente;
            HttpContext.Session["cliente"] = cliente;
            ViewBag.cliente = HttpContext.Session["paciente"];
            ///PRODUCTO
            ViewBag.Producto = GetProductosDeBaseDeDatos();
            return View("SalesModule");
        }
        [HttpPost]
        [Authorize]
        public ActionResult SalesModule(Sale sale,List<DetalleVenta> Detalles)
        {
            var cliente = context.Pacientes.ToList();
            ViewBag.paciente = cliente;

            HttpContext.Session["cliente"] = cliente;

            ViewBag.cliente = HttpContext.Session["paciente"];

            ///PRODUCTO
            ViewBag.Producto = GetProductosDeBaseDeDatos();

            ventaService.AddVenta(sale, Detalles);
            return RedirectToAction("Venta", "Optica");
        }
        [Authorize]
        public ActionResult AddCliente(string IdPaciente)
        {
            var cliente = HttpContext.Session["cliente"] as List<Paciente>;

            var paciente = cliente.SingleOrDefault(x => x.IdPaciente == IdPaciente);

            HttpContext.Session["paciente"] = paciente;
            return RedirectToAction("SalesModule");
        }
        [Authorize]
        public ActionResult ItemVenta(string id,int index)
        {
            var producto = GetProductosDeBaseDeDatos().Where(o => o.IdProducto == id).FirstOrDefault();
            ViewBag.Index = index;
            return View(producto);
        }
        [Authorize]
        public List<Producto> GetProductosDeBaseDeDatos()
        {
            var productos = context.Productos.Include(o => o.Categoria).ToList();
            return productos;
        }

        [HttpGet]
        public ActionResult Expediente(string Pacinete_Expediente)
        {
            var expediente =  expedienteService.GetListaExp(Pacinete_Expediente);
            ViewBag.id = Pacinete_Expediente;
            return View(expediente);
        }
    }
}