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

namespace PruebasUnitariasOpticaZamora.Controller
{
    [TestFixture]
    public class DoctorControllerTest
    {
        [Test]
        public void DebePoderRetorarUnaListaDeDoctores()
        {
            var serviceDoctor = new Mock<IDoctorService>();

            serviceDoctor.Setup(o => o.GetRetornarListaDoctor(null, null)).Returns(new List<Doctor>());
            var controller = new DoctorController(serviceDoctor.Object, null);

            var view = controller.List(null, null) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(view);
            Assert.IsInstanceOf<List<Doctor>>(view.Model);
            
        }
        [Test]
        public void DebePoderGuardarUnDoctor()
        {
            var docor = new Doctor()
            {
                Codigo = "ddddd",
                Nombres = "Pedro",
                Apellidos = "Huaman",
                TipoDocumento = TipoDocumento.DNI,
                NumeroDocumento = "dkdhas",
                Celular = "96482494",
                Especialidad = "Ojos",
                Username = "Pedro3u743",
                Password = "12345678910Pedro#",
                Estado = Estado.Activo
            };
            ModelStateDictionary modelState = new ModelStateDictionary();

            var iDoctorService = new Mock<IDoctorService>();
            iDoctorService.Setup(o => o.AddDoctor(docor));

            var iDoctorValidation = new Mock<IDoctorValidation>();
            iDoctorValidation.Setup(o => o.IsValid()).Returns(true);

            var controller = new DoctorController(iDoctorService.Object, iDoctorValidation.Object);

            var view = controller.Save(docor);

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
            Assert.IsNotInstanceOf<ViewResult>(view);
            iDoctorValidation.Verify(o => o.Validate(docor, modelState));
            iDoctorValidation.Verify(o => o.IsValid());
            iDoctorService.Verify(o => o.AddDoctor(docor), Times.AtLeastOnce);
        }
        [Test]
        public void NoDebePoderGuardarUnDoctor()
        {
            var docor = new Doctor() { };
            ModelStateDictionary modelState = new ModelStateDictionary();

            var iDoctorValidation = new Mock<IDoctorValidation>();
            var controller = new DoctorController(null,iDoctorValidation.Object);

            var view = controller.Save(docor);

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(view);
            iDoctorValidation.Verify(o => o.Validate(docor, modelState));
            iDoctorValidation.Verify(o => o.IsValid());
        }
        [Test]
        public void DebePoderObtenerUnDoctorModificar()
        {
            string IdDoctor = "www";
            var iDoctorService = new Mock<IDoctorService>();
            iDoctorService.Setup(o => o.DoctorModificar(IdDoctor));

            var controller = new DoctorController(iDoctorService.Object, null);
            var view = controller.Edit(IdDoctor) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            iDoctorService.Verify(o => o.DoctorModificar(IdDoctor), Times.AtLeastOnce);
        }
        [Test]
        public void DeberPoderActualizarUnDoctor()
        {
            var docor = new Doctor()
            {
                Codigo = "ddddd",
                Nombres = "Pedro",
                Apellidos = "Huaman",
                TipoDocumento = TipoDocumento.DNI,
                NumeroDocumento = "dkdhas",
                Celular = "96482494",
                Especialidad = "Ojos",
                Username = "Pedro3u743",
                Password = "12345678910Pedro#",
                Estado = Estado.Activo
            };
            ModelStateDictionary modelState = new ModelStateDictionary();

            var iDoctorService = new Mock<IDoctorService>();
            iDoctorService.Setup(o => o.UpdateDoctor(docor));

            var iDoctorValidation = new Mock<IDoctorValidation>();
            iDoctorValidation.Setup(o => o.ValidateUpdate(docor, modelState));
            iDoctorValidation.Setup(o => o.IsValid()).Returns(true);

            var controller = new DoctorController(iDoctorService.Object, iDoctorValidation.Object);

            var view = controller.Update(docor);

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
            iDoctorValidation.Verify(o => o.ValidateUpdate(docor, modelState));
            iDoctorValidation.Verify(o => o.IsValid());
            iDoctorService.Verify(o => o.UpdateDoctor(docor), Times.AtLeastOnce);
        }
        [Test]
        public void NoDeberPoderActualizarUnDoctor() 
        {
            var docor = new Doctor()
            {
                Codigo = "ddddd",
                Nombres = "Pedro",
                Apellidos = "Huaman",
                TipoDocumento = TipoDocumento.DNI,
                NumeroDocumento = "dkdhas",
                Celular = "96482494",
                Especialidad = "Ojos",
                Username = "Pedro3u743",
                Password = "12345678910Pedro#",
                Estado = Estado.Activo
            };
            ModelStateDictionary modelState = new ModelStateDictionary();

            var iDoctorValidation = new Mock<IDoctorValidation>();
            iDoctorValidation.Setup(o => o.ValidateUpdate(docor, modelState));
            iDoctorValidation.Setup(o => o.IsValid()).Returns(false);

            var controller = new DoctorController(null, iDoctorValidation.Object);
            var view = controller.Update(docor);

            Assert.IsInstanceOf<ViewResult>(view);
            iDoctorValidation.Verify(o => o.ValidateUpdate(docor, modelState));
            iDoctorValidation.Verify(o => o.IsValid());

        }
    }
}
