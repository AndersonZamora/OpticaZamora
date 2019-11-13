using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Interface.List;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Controllers
{
    public class PatientController : Controller
    {

        private IPacienteService PacienteService;
        private IPacienteValidacion PacienteValidacion;
        public PatientController(IPacienteService PacienteService, IPacienteValidacion PacienteValidacion)
        {
            this.PacienteService = PacienteService;
            this.PacienteValidacion = PacienteValidacion;
        }
        // GET: Patient
        [Authorize] ///LISTA DE DOCTORES
        public ActionResult List(string criterion)
        {
            var pacientes = PacienteService.GetRetornarListasPaciente(criterion);
            return View("List", pacientes);
        }
        //
        [Authorize]
        [HttpGet] ///GUARDAR PACIENTE GET
        public ViewResult Save()
        {
            return View("Save", new Paciente());
        }
        //
        [Authorize]
        [HttpPost] /// GUARDAR PACIENTE POST
        public ActionResult Save(Paciente paciente)
        {
            PacienteValidacion.validate(paciente, ModelState);
            if (!ModelState.IsValid)
                return View("Save", paciente);

            PacienteService.AddPaciente(paciente);
            return RedirectToAction("List");
        }
        //
        [Authorize] /// EDITAR PACIENTE
        public ViewResult Edit(string Edit_Patient)
        {
            var pacientes = PacienteService.PacienteModificar(Edit_Patient);
            return View("Edit", pacientes);
        }
        //
        [Authorize] /// ACTUALIZAR PACIENTE
        public ActionResult Update(Paciente paciente)
        {
            PacienteValidacion.validateUpdate(paciente, ModelState);
            if (!ModelState.IsValid)
                return View("Edit", paciente);

            PacienteService.UpdatePaciente(paciente);
            return RedirectToAction("List");
        }
    }
}