using Moq;
using NUnit.Framework;
using OpticaZamora.DB;
using OpticaZamora.Models;
using OpticaZamora.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitariasOpticaZamora.Services
{
    [TestFixture]
    public class ProdcutoServiceTest
    {
        [Test]
        public void SVDebePoderRetorarUnProducto()
        {
            string id = "AAA";
            var data = new List<Producto>()
            {
                new Producto {IdProducto = "AAA", CategoriaId = "ee",CodigoProducto = "sjddea2",Descripcion="producto1 de uso",Nombre ="Producto1",Precio ="20",Stock=20},
                new Producto {IdProducto = "BBB",CategoriaId = "aa",CodigoProducto = "sjdccc3",Descripcion="producto2 de uso",Nombre ="Producto2",Precio ="30",Stock=20},
                new Producto {IdProducto = "CCC",CategoriaId = "ii",CodigoProducto = "sjdttt4",Descripcion="producto3 de uso",Nombre ="Producto3",Precio ="40",Stock=20}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(o => o.Productos).Returns(dbset.Object);

            var prodcutoService = new ProdcutoService(context.Object);

            var producto = prodcutoService.ProductoModificar(id);

            Assert.AreEqual(id, producto.IdProducto);
            Assert.IsNotNull(producto);
        }
        [Test]
        public void SVNoDebePoderRetorarUnProducto()
        {
            string id = null;

            var data = new List<Producto>()
            {
                new Producto {IdProducto = "AAA", CategoriaId = "ee",CodigoProducto = "sjddea2",Descripcion="producto1 de uso",Nombre ="Producto1",Precio ="20",Stock=20},
                new Producto {IdProducto = "BBB",CategoriaId = "aa",CodigoProducto = "sjdccc3",Descripcion="producto2 de uso",Nombre ="Producto2",Precio ="30",Stock=20},
                new Producto {IdProducto = "CCC",CategoriaId = "ii",CodigoProducto = "sjdttt4",Descripcion="producto3 de uso",Nombre ="Producto3",Precio ="40",Stock=20}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(o => o.Productos).Returns(dbset.Object);

            var prodcutoService = new ProdcutoService(context.Object);

            var producto = prodcutoService.ProductoModificar(id);

            Assert.IsNull(producto);
        }
        [Test]
        public void SVDebePoderRetorarUnaListaDeProductosCuandoElCriterioSeaNulo()
        {
            string id = null;

            var data = new List<Producto>()
            {
                new Producto {IdProducto = "AAA", CategoriaId = "ee",CodigoProducto = "sjddea2",Descripcion="producto1 de uso",Nombre ="Producto1",Precio ="20",Stock=20},
                new Producto {IdProducto = "BBB",CategoriaId = "aa",CodigoProducto = "sjdccc3",Descripcion="producto2 de uso",Nombre ="Producto2",Precio ="30",Stock=20},
                new Producto {IdProducto = "CCC",CategoriaId = "ii",CodigoProducto = "sjdttt4",Descripcion="producto3 de uso",Nombre ="Producto3",Precio ="40",Stock=20}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
          
            context.Setup(a => a.Productos.Include(It.IsAny<string>())).Returns(dbset.Object);
            var prodcutoService = new ProdcutoService(context.Object);

            var producto = prodcutoService.GetRetornarListaProducto(id);

            Assert.AreEqual(3, producto.Count());
            Assert.IsNotNull(producto);
        }
        [Test]
        public void SVDebePoderRetorarUnProductoCuandoElCriterioNoSeaNulo()
        {
            string criterio = "Producto3";

            var data = new List<Producto>()
            {
                new Producto {IdProducto = "AAA", CategoriaId = "ee",CodigoProducto = "sjddea2",Descripcion="producto1 de uso",Nombre ="Producto1",Precio ="20",Stock=20},
                new Producto {IdProducto = "BBB",CategoriaId = "aa",CodigoProducto = "sjdccc3",Descripcion="producto2 de uso",Nombre ="Producto2",Precio ="30",Stock=20},
                new Producto {IdProducto = "CCC",CategoriaId = "ii",CodigoProducto = "sjdttt4",Descripcion="producto3 de uso",Nombre ="Producto3",Precio ="40",Stock=20}

            }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();

            context.Setup(a => a.Productos.Include(It.IsAny<string>())).Returns(dbset.Object);
            var prodcutoService = new ProdcutoService(context.Object);

            var producto = prodcutoService.GetRetornarListaProducto(criterio);

            Assert.AreEqual(1, producto.Count());
            Assert.IsNotNull(producto);
        }
        [Test]
        public void SVDebePodeGuardarUnProducto()
        {
            var data = new List<Producto>() { }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Productos).Returns(dbset.Object);

            var service = new ProdcutoService(context.Object);

            var producto = new Producto()
            {
                IdProducto = "AAA",
                CategoriaId = "ee",
                CodigoProducto = "sjddea2",
                Descripcion = "producto1 de uso",
                Nombre = "Producto1",
                Precio = "20",
                Stock = 20
            };
            var estado = service.AddProducto(producto);

            Assert.AreEqual(true, estado);
            Assert.IsTrue(estado);
        }
        [Test]
        public void SVDebePodeActualizarUnProducto()
        {
            var data = new List<Producto>() {

                new Producto {IdProducto = "AAA", CategoriaId = "ee",CodigoProducto = "sjddea2",Descripcion="producto1 de uso",Nombre ="Producto1",Precio ="20",Stock=20},
                new Producto {IdProducto = "BBB",CategoriaId = "aa",CodigoProducto = "sjdccc3",Descripcion="producto2 de uso",Nombre ="Producto2",Precio ="30",Stock=20},
                new Producto {IdProducto = "CCC",CategoriaId = "ii",CodigoProducto = "sjdttt4",Descripcion="producto3 de uso",Nombre ="Producto3",Precio ="40",Stock=20}

            }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Productos).Returns(dbset.Object);

            var service = new ProdcutoService(context.Object);

            var producto = new Producto()
            {
                IdProducto = "AAA",
                CategoriaId = "Lentes",
                CodigoProducto = "sjddea2",
                Descripcion = "producto1 de uso",
                Nombre = "Producto1",
                Precio = "20",
                Stock = 20
            };

            var estado = service.UpdateProducto(producto);

            Assert.AreEqual(true, estado);
            Assert.IsTrue(estado);
        }
    }
}
