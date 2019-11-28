using OpticaZamora.Interface;
using OpticaZamora.Interface.Managers;
using OpticaZamora.Interface.NumberUsers;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Controllers
{
    public class LoginController : Controller
    {
        readonly ILoginService Service;
        readonly ISessionManager Manager;
   
        public LoginController(ILoginService Service, ISessionManager Manager)
        {
            this.Service = Service;
            this.Manager = Manager;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult messenge()
        {
            return View();
        }
        public ActionResult Signin ( Sys sys , Doctor doctor)
        {
            var usuarioDB = Service.ObtenerUsuario(sys); //Obtener Super Usuario
            var DoctorDB = Service.ObenerAdmin(doctor);
    
            if (usuarioDB != null)
            {
                Manager.SetIdUsuario(usuarioDB.IdUsuario);
                Manager.SetNombreUsuario(usuarioDB.Username);
                if (usuarioDB.Rol == "Sys")
                {
                    Manager.AutenticacionUsername(sys.Username, false);
                    return RedirectToAction("Index", "Optica");
                }
            }
            if (DoctorDB != null)
            {
                if (DoctorDB.Estado == 0)
                {
                    return View("messenge");
                }
                if (DoctorDB.Estado != 0)
                {
                    return View("Index");
                }
            }
            return View("Index");
        }
    }
}