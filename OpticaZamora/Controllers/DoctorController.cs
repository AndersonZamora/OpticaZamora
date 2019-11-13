using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Interface.List;
using OpticaZamora.Interface.Managers;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Controllers
{
 
    public class DoctorController : Controller
    {
        private IDoctorService DoctorService;
        private IDoctorValidation DoctorValidation;

        public DoctorController(IDoctorService DoctorService, IDoctorValidation DoctorValidation)
        {
            this.DoctorService = DoctorService;
            this.DoctorValidation = DoctorValidation;
        }

        [Authorize] ///LISTA DE DOCTORES comprleta
        public ActionResult List(string criterio,string criterio2)
        {
            var doctores = DoctorService.GetRetornarListaDoctor(criterio,criterio2);

            return View("List", doctores);
        }
        [Authorize]
        [HttpGet] ///GUARDAR DOCTOR
        public ViewResult Save()
        {
            return View("Save", new Doctor());
        }
        [Authorize]
        [HttpPost] ///GUARDAR DOCTOR
        public ActionResult Save(Doctor doctor)
        {
            DoctorValidation.Validate(doctor, ModelState);
            if (!ModelState.IsValid)
                return View("Save", doctor);

            DoctorService.AddDoctor(doctor);
            return RedirectToAction("List");
        }
        [Authorize] ///EDITAR DOCTOR
        public ViewResult Edit(string Doctor_Edit)
        {
            var doctores = DoctorService.DoctorModificar(Doctor_Edit);
            return View("Edit", doctores);
        }
        [Authorize] ///ACTUALIZAR DOCTOR
        public ActionResult Update(Doctor doctor)
        {
            string IdDoctor = doctor.IdDoctor;
            DoctorValidation.ValidateUpdate(doctor, ModelState);
            if (!ModelState.IsValid)
                return View("Edit", doctor);

            DoctorService.UpdateDoctor(doctor);
            return RedirectToAction("List");
        }
    }
}