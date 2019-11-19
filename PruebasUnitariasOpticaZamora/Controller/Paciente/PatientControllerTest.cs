using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpticaZamora.Models;
using OpticaZamora.Interface.Validations;

namespace PruebasUnitariasOpticaZamora.Controller
{
    [TestFixture]
    public class PatientControllerTest
    {
        [Test]
        public void ListDebeRetornarVistaConListaDePaciente()
        {
            var servicePaciente = new Mock<IPacienteService>();
          
            servicePaciente.Setup(o => o.GetRetornarListasPaciente(null)).Returns(new List<Paciente>());

            var controller = new PatientController(servicePaciente.Object, null);

            var view = controller.List(null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Paciente>>(view.Model);
        }
        [Test]
        public void DebePoderGuardarUnPaciente()
        {
            var paciente = new Paciente()
            {
                TipoDocumento = TipoDocumento.DNI,
                NumeroDocumento = "148574957",
                Nombres = "Pedro",
                Apellidos = "Huaman",
                Edad = "18",
                Correo = "Pedro@gmail.com",
                Direccion = "Los anders 294",
                TipoGenero = Genero.Masculino,
                Celular = "958857223"
            };

            ModelStateDictionary modelState = new ModelStateDictionary();
            var iPacienteService = new Mock<IPacienteService>();
            iPacienteService.Setup(o => o.AddPaciente(paciente));
       
            var iPacienteValidacion = new Mock<IPacienteValidacion>();
            iPacienteValidacion.Setup(o => o.validate(paciente, modelState));
            iPacienteValidacion.Setup(o => o.IsValid()).Returns(true);


            var controller = new PatientController(iPacienteService.Object, iPacienteValidacion.Object);
            var result = controller.Save(paciente);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            iPacienteValidacion.Verify(o => o.validate(paciente, modelState));
            iPacienteValidacion.Verify(o => o.IsValid());
            iPacienteService.Verify(o => o.AddPaciente(paciente), Times.AtLeastOnce);
        }
        [Test]
        public void NoDebePoderGuardarUnPaciente()
        {
            var paciente = new Paciente(){};

            ModelStateDictionary modelState = new ModelStateDictionary();
            var iPacienteService = new Mock<IPacienteService>();
            iPacienteService.Setup(o => o.AddPaciente(paciente));

            var iPacienteValidacion = new Mock<IPacienteValidacion>();
            iPacienteValidacion.Setup(o => o.validate(paciente, modelState));
            iPacienteValidacion.Setup(o => o.IsValid()).Returns(false);

            var controller = new PatientController(iPacienteService.Object, iPacienteValidacion.Object);
            var result = controller.Save(paciente);

            Assert.IsInstanceOf<ViewResult>(result);
            iPacienteValidacion.Verify(o => o.validate(paciente, modelState));
            iPacienteValidacion.Verify(o => o.IsValid());
            iPacienteService.Verify(o => o.AddPaciente(paciente), Times.Never);
        }
        [Test]
        public void DebePoderObtenerUnPacienteModificar()
        {
            string IdPaciente = "ffff";

            var iPacienteService = new Mock<IPacienteService>();
            iPacienteService.Setup(o => o.PacienteModificar(IdPaciente));

            var controller = new PatientController(iPacienteService.Object,null);
            var resultado = controller.Edit(IdPaciente) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(resultado);
            iPacienteService.Verify(o => o.PacienteModificar(IdPaciente), Times.AtLeastOnce);
        }
        [Test]
        public void DebePoderActualizarUnPaciente()
        {
            var paciente = new Paciente()
            {
                TipoDocumento = TipoDocumento.DNI,
                NumeroDocumento = "148574957",
                Nombres = "Pedro",
                Apellidos = "Huaman",
                Edad = "18",
                Correo = "Pedro@gmail.com",
                Direccion = "Los anders 294",
                TipoGenero = Genero.Masculino,
                Celular = "958857223"
            };

            ModelStateDictionary modelState = new ModelStateDictionary();
            var iPacienteService = new Mock<IPacienteService>();
            iPacienteService.Setup(a => a.UpdatePaciente(paciente));

            var iPacienteValidacion = new Mock<IPacienteValidacion>();
            iPacienteValidacion.Setup(o => o.IsValid()).Returns(true);

            var controller = new PatientController(iPacienteService.Object, iPacienteValidacion.Object);
            var result = controller.Update(paciente);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            iPacienteValidacion.Verify(o => o.validateUpdate(paciente, modelState));
            iPacienteValidacion.Verify(o => o.IsValid());
            iPacienteService.Verify(o => o.UpdatePaciente(paciente), Times.AtLeastOnce);

        }
        [Test]
        public void NoDebePoderActualizarUnPaciente()
        {
            var paciente = new Paciente(){};

            ModelStateDictionary modelState = new ModelStateDictionary();
       
            var iPacienteValidacion = new Mock<IPacienteValidacion>();
            iPacienteValidacion.Setup(o => o.validateUpdate(paciente, modelState));
            iPacienteValidacion.Setup(o => o.IsValid()).Returns(false);
            var controller = new PatientController(null, iPacienteValidacion.Object);
            var result = controller.Update(paciente);

            Assert.IsInstanceOf<ViewResult>(result);
            iPacienteValidacion.Verify(o => o.validateUpdate(paciente, modelState));
            iPacienteValidacion.Verify(o => o.IsValid());
        }
    }
}
