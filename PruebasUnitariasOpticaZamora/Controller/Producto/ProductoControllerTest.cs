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
    public class ProductoControllerTest
    {
        [Test]
        public void ListDebeRetornarVistaConListaDeProducto()
        {
            var service = new Mock<IProdcutoService>();

            service.Setup(a => a.GetRetornarListaProducto(null)).Returns(new List<Producto>());

            var controller = new ProductController(service.Object, null, null);

            var view = controller.List(null) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Producto>>(view.Model);
        }
        [Test]
        public void DebePoderGuardarUnProducto()
        {
            var producto = new Producto
            {
                CodigoProducto = "dkjj5",
                Nombre = "Producto1",
                Precio = "30.3",
                Stock = 20,
                Descripcion = "descripcion",
                CategoriaId = "CategoriaId"
            };
            ModelStateDictionary modelState = new ModelStateDictionary();

            var iProdcutoService = new Mock<IProdcutoService>();
            iProdcutoService.Setup(o => o.AddProducto(producto));

            var iProdcutoValidation = new Mock<IProdcutoValidation>();
            iProdcutoValidation.Setup(o => o.Validate(producto, modelState));
            iProdcutoValidation.Setup(o => o.IsValid()).Returns(true);

            var iCategoriaService = new Mock<ICategoriaService>();

            var controller = new ProductController(iProdcutoService.Object, iProdcutoValidation.Object, iCategoriaService.Object);
            var result = controller.Save(producto);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            Assert.IsNotInstanceOf<ViewResult>(result);
            iProdcutoValidation.Verify(o => o.Validate(producto, modelState));
            iProdcutoValidation.Verify(o => o.IsValid());
            iProdcutoService.Verify(o => o.AddProducto(producto), Times.AtLeastOnce);
        }
        [Test]
        public void NoDebePoderGuardarUnProducto()
        {
            var producto = new Producto {};
            ModelStateDictionary modelState = new ModelStateDictionary();

            var iProdcutoService = new Mock<IProdcutoService>();
            iProdcutoService.Setup(o => o.AddProducto(producto));

            var iProdcutoValidation = new Mock<IProdcutoValidation>();
            iProdcutoValidation.Setup(o => o.Validate(producto, modelState));
            iProdcutoValidation.Setup(o => o.IsValid()).Returns(false);

            var iCategoriaService = new Mock<ICategoriaService>();

            var controller = new ProductController(iProdcutoService.Object, iProdcutoValidation.Object, iCategoriaService.Object);
            var result = controller.Save(producto);

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void DebePoderObtenerUnProductoModificar()
        {
            string IdProucto = "ffff";

            var iProdcutoService = new Mock<IProdcutoService>();
            iProdcutoService.Setup(o => o.ProductoModificar(IdProucto));

            var iCategoriaService = new Mock<ICategoriaService>();

            var controller = new ProductController(iProdcutoService.Object, null, iCategoriaService.Object);
            var resultado = controller.Edit(IdProucto) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(resultado);

            iProdcutoService.Verify(o => o.ProductoModificar(IdProucto), Times.AtLeastOnce);

        }
        [Test]
        public void DeberPoderActualizarUnProducto()
        {
            var producto = new Producto
            {
                CodigoProducto = "dkjj5",
                Nombre = "Producto1",
                Precio = "30.3",
                Stock = 20,
                Descripcion = "descripcion",
                CategoriaId = "CategoriaId"
            };
            var iProdcutoService = new Mock<IProdcutoService>();
            iProdcutoService.Setup(o => o.AddProducto(producto));

            var iProdcutoValidation = new Mock<IProdcutoValidation>();
            iProdcutoValidation.Setup(o => o.IsValid()).Returns(true);

            var categoria = new Mock<ICategoriaService>();

            var controller = new ProductController(iProdcutoService.Object, iProdcutoValidation.Object, categoria.Object);

            var resultado = controller.Update(producto);

            Assert.IsInstanceOf<RedirectToRouteResult>(resultado);
            Assert.IsNotInstanceOf<ViewResult>(resultado);
        }
        [Test]
        public void NoDeberPoderActualizarUnProducto()
        {
            var producto = new Producto{};
            var iProdcutoService = new Mock<IProdcutoService>();
            iProdcutoService.Setup(o => o.AddProducto(producto));

            var iProdcutoValidation = new Mock<IProdcutoValidation>();
            iProdcutoValidation.Setup(o => o.IsValid()).Returns(false);

            var categoria = new Mock<ICategoriaService>();

            var controller = new ProductController(iProdcutoService.Object, iProdcutoValidation.Object, categoria.Object);

            var resultado = controller.Update(producto);

            Assert.IsInstanceOf<ViewResult>(resultado);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(resultado);
        }
    }
}
