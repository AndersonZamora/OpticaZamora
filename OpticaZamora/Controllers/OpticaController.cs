using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Interface.List;
using OpticaZamora.Interface.NumberUsers;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using System.Web.Services;
using System.Web.SessionState;
namespace OpticaZamora.Controllers
{
    public class OpticaController : Controller
    {
        
        readonly IVentaService VentaService;
        readonly IExitService exit;
        public OpticaController(IExitService exit,IVentaService VentaService)
        {
            ///Deslogeo
            this.exit = exit;
            ///Venta
            this.VentaService = VentaService;
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Venta()
        {
            var ventas = VentaService.Ventas();
            return View("Venta", ventas);
        }
        public ActionResult logOff()
        {
            exit.logOff();
            return RedirectToAction("Index", "Login");
        }
      
    }

}