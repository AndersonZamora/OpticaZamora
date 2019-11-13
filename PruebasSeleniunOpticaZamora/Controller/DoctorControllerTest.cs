using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.Interface;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebasSeleniunOpticaZamora.Controller
{
    [TestFixture]
    public class DoctorControllerTest
    {
        [Test]
        public void IndexDebeRetornarVistaConListaDeDoctores()
        {
            var serviceDoctor = new Mock<IDoctorService>();

            serviceDoctor.Setup(o => o.GetRetornarListaDoctor(null,null)).Returns(new List<Doctor>());

            var controller = new DoctorController(serviceDoctor.Object, null);

            var view = controller.List(null,null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Doctor>>(view.Model);
        }
        [Test]
        public void DebeAddDoctor()
        {
            var doctor = new Doctor()
            {
                TipoDocumento = TipoDocumento.DNI,
                NumeroDocumento = "46354888",
                Codigo = "N00008",
                Nombres = "Pavlo",
                Apellidos = "Shepherd",
                Celular = "964224346",
                Especialidad = "ojos",
                Estado = Estado.Activo,
                IdDoctor = "sss",
                Username = "Anderson",
                Password = "LoveMeHarder122221"
            };
            var modelState = new ModelStateDictionary();

            var serviceValidacion = new Mock<IDoctorValidation>();

            serviceValidacion.Setup(a => a.Validate(doctor, modelState));
            // serviceValidacion.Setup(a => a.IsValid()).Returns(true);

            var serviceDoctor = new Mock<IDoctorService>();
            serviceDoctor.Setup(a => a.AddDoctor(doctor));

            var controller = new DoctorController(serviceDoctor.Object, serviceValidacion.Object);
            var result = controller.Save(doctor) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}
