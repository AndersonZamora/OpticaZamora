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
    public class CategoriaServiceTest
    {
        [Test]
        public void SVDebePoderRetonarUnaListaDeCATegoriasCuandoSeaNuloElCriterio()
        {
            string criterio = null;
            var data = new List<Categoria>()
            {
                new Categoria {Nombre = "Categoria1"},
                new Categoria {Nombre = "Categoria2"},
                new Categoria {Nombre = "Categoria3"},
                new Categoria {Nombre = "Categoria4"}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Categoria>>();
       

            dbset.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Categorias).Returns(dbset.Object);

            var service = new CategoriaService(context.Object);

            var resultado = service.GetRetornarListaCategoria(criterio);

            Assert.AreEqual(4, resultado.Count());
            Assert.IsNotNull(resultado);
        }
        [Test]
        public void SVDebePoderRetonarUnaCATegoriasCuandoSeNoseaNuloElCriterio()
        {
            string criterio = "Categoria1";
            var data = new List<Categoria>()
            {
                new Categoria {Nombre = "Categoria1"},
                new Categoria {Nombre = "Categoria2"},
                new Categoria {Nombre = "Categoria3"},
                new Categoria {Nombre = "Categoria4"}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Categoria>>();

            dbset.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Categorias).Returns(dbset.Object);

            var service = new CategoriaService(context.Object);

            var resultado = service.GetRetornarListaCategoria(criterio);

            Assert.AreEqual(1, resultado.Count());
            Assert.IsNotNull(resultado);
        }
        [Test]
        public void SVDebePoderRetorarUnDeUnaCategoria()
        {
            string id = "1";

            var data = new List<Categoria>()
            {
                new Categoria {IdCategoria="1", Nombre = "Categoria1"},
                new Categoria {IdCategoria="2",Nombre = "Categoria2"},
                new Categoria {IdCategoria="3",Nombre = "Categoria3"},
                new Categoria {IdCategoria="3",Nombre = "Categoria4"}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Categoria>>();

            dbset.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Categorias).Returns(dbset.Object);
            var service = new CategoriaService(context.Object);

            var resultado = service.CategoriaModificar(id);

            Assert.AreEqual(id, resultado.IdCategoria);
            Assert.IsNotNull(resultado);
        }
        [Test]
        public void SVNoDebePoderRetorarUnDeUnaCategoria()
        {
            string id = "5";

            var data = new List<Categoria>()
            {
                new Categoria {IdCategoria="1", Nombre = "Categoria1"},
                new Categoria {IdCategoria="2",Nombre = "Categoria2"},
                new Categoria {IdCategoria="3",Nombre = "Categoria3"},
                new Categoria {IdCategoria="4",Nombre = "Categoria4"}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Categoria>>();

            dbset.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Categorias).Returns(dbset.Object);
            var service = new CategoriaService(context.Object);

            var resultado = service.CategoriaModificar(id);
            Assert.IsNull(resultado);
        }
        [Test]
        public void SVDebePoderGuadarUnaCategoria()
        {
            var data = new List<Categoria>
            { }.AsQueryable();

            var dbset = new Mock<DbSet<Categoria>>();
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Categorias).Returns(dbset.Object);

            var service = new CategoriaService(context.Object);

            var categoria = new Categoria
            {
                Nombre = "Categoria1"
            };

            var guardar = service.AddCategoria(categoria);
            Assert.AreEqual(true, guardar);
            Assert.IsTrue(guardar);
        }
        [Test]
        public void SVDebePoderActualizarUnaCategoria()
        {
            var data = new List<Categoria>
            {
                new Categoria{IdCategoria="1", Nombre = "CategoriaA"},
                new Categoria{IdCategoria="2", Nombre = "CategoriaB"}

            }.AsQueryable();

            var dbset = new Mock<DbSet<Categoria>>();
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Categoria>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Categorias).Returns(dbset.Object);

            var service = new CategoriaService(context.Object);
            var categoria = new Categoria
            {
                IdCategoria = "1",
                Nombre = "CategoriaC"
            };
            var estado = service.UpdateCategoria(categoria);
            Assert.AreEqual(true, estado);
            Assert.IsTrue(estado);
        }
    }
}
