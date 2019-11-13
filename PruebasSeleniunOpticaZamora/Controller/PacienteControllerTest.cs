using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using OpticaZamora.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebasSeleniunOpticaZamora.Controller
{
    [TestFixture]
    public class PacienteControllerTest
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
    }
}
