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
    public class LoginServiceTest
    {
        [Test]
        public void DeberPoderObetenerRetornarUnUsuario()
        {
            var data = new List<Sys>()
            {
                new Sys {Username = "Anderson",Password="12345678"},
                new Sys {Username = "Alex",Password="48275932"},
                new Sys {Username = "Jimmy",Password="64829455"}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Sys>>();
            dbset.As<IQueryable<Sys>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Sys>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Sys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Sys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Syss).Returns(dbset.Object);
            var loginService = new LoginService(context.Object);

            Sys sys = new Sys() { Username = "Anderson", Password = "12345678"};

            var ObtenereUsuario = loginService.ObtenerUsuario(sys);
            Assert.IsNotNull(ObtenereUsuario);
        }
        [Test]
        public void NoDeberPoderObetenerRetornarUnUsuario()
        {
            var data = new List<Sys>()
            {
                new Sys {Username = "Anderson",Password="12345678"},
                new Sys {Username = "Alex",Password="48275932"},
                new Sys {Username = "Jimmy",Password="64829455"}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Sys>>();
            dbset.As<IQueryable<Sys>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Sys>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Sys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Sys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Syss).Returns(dbset.Object);
            var loginService = new LoginService(context.Object);

            Sys sys = new Sys() { Username = "Pepe", Password = "4924" };

            var ObtenereUsuario = loginService.ObtenerUsuario(sys);
            Assert.IsNull(ObtenereUsuario);
        }
    }
}
