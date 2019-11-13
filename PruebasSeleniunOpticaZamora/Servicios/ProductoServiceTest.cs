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

namespace PruebasSeleniunOpticaZamora.Servicios
{
    [TestFixture]
    public class ProductoServiceTest
    {
        [Test]
       // [Ignore("Mock include")]
        public void DebeGetRetornarListaProductosCuandoCriterioNull()
        {
            var categoria = new List<Categoria>
            {
                new Categoria {IdCategoria="aa",Nombre="aa"},
                new Categoria {IdCategoria="bb",Nombre="bb"}
            }.AsQueryable();

            var data = new List<Producto>
            {
                new Producto {

                    CategoriaId ="aaa",
                    Categoria = new Categoria {IdCategoria="aa",Nombre="aa"},
                    CodigoProducto ="aaa",
                    Descripcion ="Para tomar",
                    IdProducto ="Producto01",
                    Nombre = "Gaseosa",
                    Precio = "20",
                    Stock = 10
                },
                  new Producto {

                    CategoriaId ="categoria2",
                    Categoria = new Categoria {IdCategoria="bb",Nombre="bb"},
                    CodigoProducto ="bb",
                    Descripcion ="Para beber",
                    IdProducto ="Producto02",
                    Nombre = "Gaseosa de mesa",
                    Precio = "20",
                    Stock = 10,
                    
                }
            }.AsQueryable();

            var dbset = new Mock<DbSet<Producto>>();
            // parentsDbSet1.Setup(x => x.Include(It.IsAny<string>())).Returns(parentsDbSet2.Object);
         
            var dbset2 = new Mock<DbSet<Categoria>>();

            dbset.As<IQueryable<Producto>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Producto>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Producto>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Producto>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            dbset2.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(categoria.Provider);
            dbset2.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(categoria.Expression);
            dbset2.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(categoria.ElementType);
            dbset2.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(categoria.GetEnumerator());

            var context = new Mock<OpticaContext>();

            context.Setup(a => a.Productos.Include(It.IsAny<string>())).Returns(dbset.Object);
            context.Setup(a => a.Categorias).Returns(dbset2.Object);
            var service = new ProdcutoService(context.Object);

            var productos = service.GetRetornarListaProducto("Gaseosa");
            Assert.AreEqual(2, productos.Count());
        }
    }
}
