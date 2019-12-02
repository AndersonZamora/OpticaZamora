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
    public class CasefileController : Controller
    {
        readonly IExpedienteService ExpedienteService;
        readonly ISessionList SessionList;
        public CasefileController(IExpedienteService ExpedienteService, ISessionList SessionList)
        {
            this.ExpedienteService = ExpedienteService;
            this.SessionList = SessionList;
        }
        [HttpGet]
        [Authorize] ///EXPEDIENTE DE UN PACIENTE
        // GET: Casefile
        public ActionResult Espxdiexte(string Paciente_Expediente, string crieterio)
        {
            var expedientes = ExpedienteService.GetListaExpedientes(Paciente_Expediente);
            var paciente = SessionList.SetListaPaciente(Paciente_Expediente);
            ViewBag.paciente = paciente;
            return View("Espxdiexte", expedientes);
        }
        [HttpGet] ///GUARDAR UN EXPEDIENTE
        [Authorize]
        public ViewResult EspxdiexteSave(string Save_Espxdiexte_Paciente)
        {
            ListaDoctoresPacientes(Save_Espxdiexte_Paciente);
            return View("EspxdiexteSave", new Expediente());
        }
        [Authorize]
        [HttpPost] ///GUARDAR UN EXPEDIENTE
        public ActionResult SaveEspxdiexte(Expediente expediente)
        {
            ExpedienteService.AddAExpediente(expediente);
            var expedientes = ExpedienteService.GetListaExpedientes(expediente.PacienteId);
            var paciente = SessionList.SetListaPaciente(expediente.PacienteId);
            ViewBag.paciente = paciente;
            return View("Espxdiexte", expedientes);
        }
        //File Detail
        [Authorize] ///DETALLE DE EXPEDIENTE
        public ActionResult EspxdiexteDetail(string Espxdiexte_Detail)
        {
            var expedientes = ExpedienteService.ExpedientePaciente(Espxdiexte_Detail);
            return View("EspxdiexteDetail", expedientes);
        }
        [Authorize] ///LISTA DE DOCTORES
        public void ListaDoctoresPacientes(string Save_File_Paciente)
        {
            var doctor = SessionList.SetListaDocotores();
            ViewBag.Docotres = new SelectList(doctor, "IdDoctor", "Nombres");
            var paciente = SessionList.SetListaPaciente(Save_File_Paciente);
            ViewBag.PacinetesDetalle = paciente;

            ViewBag.Pacientes = new SelectList(paciente, "IdPaciente", "Nombres");
        }
    }
}