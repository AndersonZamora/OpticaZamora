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
        
        readonly IVentaService ventaService;
        readonly IExpedienteService expedienteService;
        public VentaController(IVentaService ventaService, IExpedienteService expedienteService)
        {
            this.ventaService = ventaService;
            this.expedienteService = expedienteService;
        }
        [HttpGet]
        [Authorize]
        public ViewResult SalesModule()
        {
            var cliente = ventaService.Pacientes();
            ViewBag.paciente = cliente;
            HttpContext.Session["cliente"] = cliente;
            ViewBag.cliente = HttpContext.Session["paciente"];

            ViewBag.Producto = ventaService.Productos();
            return View("SalesModule");
        }
        [HttpPost]
        [Authorize]
        public ActionResult SalesModule(Sale sale,List<DetalleVenta> Detalles)
        {
            var cliente = ventaService.Pacientes();
            ViewBag.paciente = cliente;

            HttpContext.Session["cliente"] = cliente;

            ViewBag.cliente = HttpContext.Session["paciente"];

            ViewBag.Producto = ventaService.Productos();

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
            var producto = ventaService.GetProductosDeBaseDeDatos(id);
            ViewBag.Index = index;
            return View(producto);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Expediente(string Pacinete_Expediente)
        {
            var expediente =  expedienteService.GetListaExp(Pacinete_Expediente);
            ViewBag.id = Pacinete_Expediente;
            return View(expediente);
        }
    }
}