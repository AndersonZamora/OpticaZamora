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

namespace PruebasSeleniunOpticaZamora.PruebasUnitarias.CategoriaPrueba
{
    [TestFixture]
    public class CategoriaControllerTest
    {
        [Test]
        public void GuardarCategoria()
        {
            var categoria = new Categoria()
            {
                Nombre = "Lentes para Niños"
            };

            var mock = new Mock<ICategoriaService>();
            mock.Setup(o => o.AddCategoria(categoria));

            var validacion = new Mock<ICategoriaValidation>();
            validacion.Setup(o => o.Validate(categoria, null));
            validacion.Setup(o => o.IsValid()).Returns(true);

            var controller = new CategoryController(mock.Object, validacion.Object);
            var result = controller.Save(categoria) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.AddCategoria(categoria), Times.Once);
        }
        [Test]
        public void TestActualizarCategoria()
        {
            var cat = new Categoria
            {
                Nombre = "Lentes para niños"
            };
            var mock = new Mock<ICategoriaService>();
            mock.Setup(o => o.UpdateCategoria(cat));

            var validacion = new Mock<ICategoriaValidation>();
            validacion.Setup(o => o.Validate(cat, null));
            validacion.Setup(o => o.IsValid()).Returns(true);

            var controller = new CategoryController(mock.Object, validacion.Object);
            var result = controller.Update(cat) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.UpdateCategoria(cat), Times.Once);
        }
    }
}
