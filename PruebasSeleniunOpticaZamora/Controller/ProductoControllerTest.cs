using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.Interface;
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
    public class ProductoControllerTest
    {
        [Test]
        public void ListDebeRetornarVistaConListaDeProducto()
        {
            var service = new Mock<IProdcutoService>();

            service.Setup(a => a.GetRetornarListaProducto(null)).Returns(new List<Producto>());

            var controller = new ProductController(service.Object, null,null);

            var  view = controller.List(null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Producto>>(view.Model);
        }
    }
}
