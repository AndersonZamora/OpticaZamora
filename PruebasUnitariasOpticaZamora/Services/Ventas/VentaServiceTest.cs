using Moq;
using NUnit.Framework;
using OpticaZamora.DB;
using OpticaZamora.Interface;
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
    public class VentaServiceTest
    {
        [Test]
        public void DebePoderDevolverUnaListaDeVentas()
        {
            var data = new List<Sale>()
            {
                new Sale{ PacienteId = "1",FechaVenta = new DateTime(2019,2,2),Total="10"},
                new Sale{ PacienteId = "2",FechaVenta = new DateTime(2019,3,2),Total="20"},
                new Sale{ PacienteId = "3",FechaVenta = new DateTime(2019,4,2),Total="30"}

            }.AsQueryable();

            var dbset = new Mock<DbSet<Sale>>();
            dbset.As<IQueryable<Sale>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Sale>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Sale>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Sale>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Sales.Include(It.IsAny<string>())).Returns(dbset.Object);
 
            var ventaService = new VentaService(context.Object);

            var listaVentas = ventaService.Ventas();
            Assert.IsNotNull(listaVentas);
            Assert.AreEqual(3, listaVentas.Count);
        }
        [Test]
        public void DebePoderAgregarUnaVenta()
        {
            var data1 = new List<Sale>() { }.AsQueryable();
            
            var data = new List<DetalleVenta>() { }.AsQueryable();

            var dbset = new Mock<DbSet<DetalleVenta>>();
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dbset2 = new Mock<DbSet<Sale>>(); 
            dbset.As<IQueryable<Sale>>().Setup(m => m.Provider).Returns(data1.Provider);
            dbset.As<IQueryable<Sale>>().Setup(m => m.Expression).Returns(data1.Expression);
            dbset.As<IQueryable<Sale>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            dbset.As<IQueryable<Sale>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.DetalleVentas).Returns(dbset.Object);
            context.Setup(a => a.Sales).Returns(dbset2.Object);

            var iVentaService = new Mock<IVentaService>();
            var sale = new Sale() { IdSALE="aa" };
            var detalleVenta = new List<DetalleVenta>()
            {
                 new DetalleVenta {Id="ddd",VentaId="q22",Cantidad="2",ProductoId = "33",ProductoNombre = "A",ProductoCategoria = "D",ProductoPrecio="20",Total="40"},
                 new DetalleVenta {Id="dd",VentaId="q23",Cantidad="3",ProductoId = "44",ProductoNombre = "B",ProductoCategoria = "E",ProductoPrecio="30",Total="90"},
                 new DetalleVenta {Id="aaa",VentaId="q24",Cantidad="4",ProductoId = "44",ProductoNombre = "C",ProductoCategoria = "F",ProductoPrecio="40",Total="160"},
            };

            var ventaService = new VentaService(context.Object);
            var add = ventaService.AddVenta(sale, detalleVenta);
            Assert.IsTrue(add);
            Assert.AreEqual(true, add);
            Assert.AreNotEqual(false, add);
        }
        [Test]
        public void NoDebePoderAgregarUnaVenta()
        {
            var data1 = new List<Sale>() { }.AsQueryable();

            var data = new List<DetalleVenta>() { }.AsQueryable();

            var dbset = new Mock<DbSet<DetalleVenta>>();
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<DetalleVenta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dbset2 = new Mock<DbSet<Sale>>();
            dbset.As<IQueryable<Sale>>().Setup(m => m.Provider).Returns(data1.Provider);
            dbset.As<IQueryable<Sale>>().Setup(m => m.Expression).Returns(data1.Expression);
            dbset.As<IQueryable<Sale>>().Setup(m => m.ElementType).Returns(data1.ElementType);
            dbset.As<IQueryable<Sale>>().Setup(m => m.GetEnumerator()).Returns(data1.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.DetalleVentas).Returns(dbset.Object);
            context.Setup(a => a.Sales).Returns(dbset2.Object);

            var iVentaService = new Mock<IVentaService>();
            var sale = new Sale() { IdSALE = null };
            var detalleVenta = new List<DetalleVenta>()
            {
                 new DetalleVenta {Id="ddd",VentaId="q22",Cantidad="2",ProductoId = "33",ProductoNombre = "A",ProductoCategoria = "D",ProductoPrecio="20",Total="40"},
                 new DetalleVenta {Id="dd",VentaId="q23",Cantidad="3",ProductoId = "44",ProductoNombre = "B",ProductoCategoria = "E",ProductoPrecio="30",Total="90"},
                 new DetalleVenta {Id="aaa",VentaId="q24",Cantidad="4",ProductoId = "44",ProductoNombre = "C",ProductoCategoria = "F",ProductoPrecio="40",Total="160"},
            };
            var ventaService = new VentaService(context.Object);
            var add = ventaService.AddVenta(sale, detalleVenta);
            Assert.IsFalse(add);
            Assert.AreEqual(false, add);
            Assert.AreNotEqual(true, add);
        }
    }
}
