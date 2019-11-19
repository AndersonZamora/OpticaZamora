using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebasUnitariasOpticaZamora.Controller.Optica
{
    [TestFixture]
    public class OpticaControllerTest
    {
        [Test]
        public void DebePoderRetornarUnaListaDeVentas()
        {
            var data = new List<Sale>()
            {
                new Sale{ PacienteId = "1",FechaVenta = new DateTime(2019,2,2),Total="10"},
                new Sale{ PacienteId = "2",FechaVenta = new DateTime(2019,3,2),Total="20"},
                new Sale{ PacienteId = "3",FechaVenta = new DateTime(2019,4,2),Total="30"}
            };

            var VentaService = new Mock<IVentaService>();
            VentaService.Setup(o => o.Ventas()).Returns(data);

            var controller = new OpticaController(null,VentaService.Object);
            controller.ControllerContext = MockControllerContext();

            var view = controller.Venta();
            Assert.IsInstanceOf<ViewResult>(view);

        }
        public ControllerContext MockControllerContext()
        {
            var controllerContext = new Mock<ControllerContext>();
            var httpContext = new Mock<HttpContextBase>();
            controllerContext.Setup(o => o.HttpContext).Returns(httpContext.Object);

            return controllerContext.Object;
        }
    }
}
