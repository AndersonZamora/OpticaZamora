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

namespace PruebasSeleniunOpticaZamora.PruebasUnitarias.ProductoPrueba
{
    [TestFixture]
    public class ProductoControllerTest
    {
        [Test]
        public void GuardarProducto()
        {
            var producto = new Producto()
            {
                CodigoProducto = "xyz123r",
                Nombre = "Lentes 1",
                Precio = "246",
                Stock = 12,
                Descripcion = "abccc",
                CategoriaId = "4fdae1cc-e70f-4360-b444-24ca0552ba57",
            };
            var mock = new Mock<IProdcutoService>();
            mock.Setup(o => o.AddProducto(producto));

            var validacion = new Mock<IProdcutoValidation>();
            validacion.Setup(o => o.Validate(producto, null));
            validacion.Setup(o => o.IsValid()).Returns(true);

            var categoria = new Mock<ICategoriaService>();

            var controller = new ProductController(mock.Object, validacion.Object, categoria.Object);
            var result = controller.Save(producto) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.AddProducto(producto), Times.Once);
        }
        [Test]
        public void TestEditarProducto()
        {
            var producto = new Producto
            {
                CodigoProducto = "xyz123r",
                Nombre = "Lentes 1",
                Precio = "246",
                Stock = 12,
                Descripcion = "abccc",
                CategoriaId = "4fdae1cc-e70f-4360-b444-24ca0552ba57",

            };
            var mock = new Mock<IProdcutoService>();
            mock.Setup(o => o.AddProducto(producto));

            var criterio = new Mock<ICategoriaService>();

            var categoria = new Mock<ICategoriaService>();

            var validacion = new Mock<IProdcutoValidation>();
            validacion.Setup(o => o.Validate(producto, null));
            validacion.Setup(o => o.IsValid()).Returns(true);

            var controller = new ProductController(mock.Object, validacion.Object,categoria.Object);
            var result = controller.Save(producto) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.AddProducto(producto), Times.Once);
        }
    }
}
