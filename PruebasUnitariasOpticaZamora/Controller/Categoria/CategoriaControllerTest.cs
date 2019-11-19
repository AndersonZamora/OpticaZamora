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
    public class CategoriaControllerTest
    {
        [Test]
        public void DebepoderRetornarUnaListaDeCategorias()
        {
            string criterio = null;
            var service = new Mock<ICategoriaService>();
            service.Setup(o => o.GetRetornarListaCategoria(null)).Returns(new List<Categoria>());

            var controller = new CategoryController(service.Object,null);

            var view = controller.List(criterio) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Categoria>>(view.Model);
        }
        [Test]
        public void DebePoderGuardarUnaCategoria()
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
            Assert.IsNotInstanceOf<ViewResult>(result);
        }
        [Test]
        public void NoDebePoderGuardarUnaCategoria()
        {
            var categoria = new Categoria()
            {
                Nombre = "Lentes para Niños"
            };

            var mock = new Mock<ICategoriaService>();
            mock.Setup(o => o.AddCategoria(categoria));

            var validacion = new Mock<ICategoriaValidation>();
            validacion.Setup(o => o.Validate(categoria, null));
            validacion.Setup(o => o.IsValid()).Returns(false);

            var controller = new CategoryController(mock.Object, validacion.Object);
            var result = controller.Save(categoria) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void DebePoderObtenerUnaCategoriaModificar()
        {
            string IdCategoria = "ffff";

            var iCategoriaService = new Mock<ICategoriaService>();
            iCategoriaService.Setup(o => o.CategoriaModificar(IdCategoria));
             

            var controller = new CategoryController(iCategoriaService.Object,null);
            var resultado = controller.Edit(IdCategoria) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void DeberPoderActualizarUnaCateagoria()
        {
            var categoria = new Categoria()
            {
                Nombre = "Categoria A"
            };
            ModelStateDictionary modelState = new ModelStateDictionary();
            var iCategoriaService = new Mock<ICategoriaService>();
            iCategoriaService.Setup(a => a.UpdateCategoria(categoria));

            var iCategoriasValidate = new Mock<ICategoriaValidation>();
            iCategoriasValidate.Setup(o => o.IsValid()).Returns(true);

            var controller = new CategoryController(iCategoriaService.Object, iCategoriasValidate.Object);

            var resultado = controller.Update(categoria);

            Assert.IsInstanceOf<RedirectToRouteResult>(resultado);
            Assert.IsNotInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void NoDeberPoderActualizarUnaCateagoria()
        {
            var categoria = new Categoria()
            {
                Nombre = "Categoria A"
            };
            ModelStateDictionary modelState = new ModelStateDictionary();
            var iCategoriaService = new Mock<ICategoriaService>();
            iCategoriaService.Setup(a => a.UpdateCategoria(categoria));

            var iCategoriasValidate = new Mock<ICategoriaValidation>();
            iCategoriasValidate.Setup(o => o.IsValid()).Returns(false);

            var controller = new CategoryController(iCategoriaService.Object, iCategoriasValidate.Object);

            var resultado = controller.Update(categoria);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
    }
}
