using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using OpticaZamora.Services;
using OpticaZamora.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebasSeleniunOpticaZamora.Servicios
{
    [TestFixture]
    public class DoctorServiceTest
    {
        [Test]
        public void DebeGetRetornarListaDoctoresCuandoCriterioNull()
        {
     
            var data = new List<Doctor>
            {
                new Doctor {Apellidos ="Shepherd",Celular = "111",Codigo="ffff",Especialidad ="ojos",Estado = Estado.Activo,IdDoctor="sss",Nombres="Derek",NumeroDocumento="3333",Password="ddddd",TipoDocumento = TipoDocumento.DNI},
                new Doctor {Apellidos ="Silva",Celular = "111",Codigo="ffff",Especialidad ="ojos",Estado = Estado.Activo,IdDoctor="sss",Nombres="Arellanos",NumeroDocumento="3333",Password="ddddd",TipoDocumento = TipoDocumento.DNI}


            }.AsQueryable();

            var dbset = new Mock<DbSet<Doctor>>();
            var count = data.Count();

            dbset.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context2 = new Mock<OpticaContext>();
            context2.Setup(a => a.Doctores).Returns(dbset.Object);

            var servie = new DoctorService(context2.Object);

            var doctores = servie.GetRetornarListaDoctor(null,null);
            Assert.AreEqual(2, doctores.Count());
        }
        [Test]
        public void DebeGetRetornarListaDoctoresCuandoCriterioBusqueda()
        {
            var data = new List<Doctor>
            {
                new Doctor {Apellidos ="Shepherd",Celular = "111",Codigo="ffff",Especialidad ="ojos",Estado = Estado.Activo,IdDoctor="sss",Nombres="Derek",NumeroDocumento="3333",Password="ddddd",TipoDocumento = TipoDocumento.DNI},
                new Doctor {Apellidos ="Silva",Celular = "111",Codigo="ffff",Especialidad ="ojos",Estado = Estado.Activo,IdDoctor="sss",Nombres="Arellanos",NumeroDocumento="3333",Password="ddddd",TipoDocumento = TipoDocumento.DNI}

            }.AsQueryable();
            var dbset = new Mock<DbSet<Doctor>>();

            dbset.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context2 = new Mock<OpticaContext>();
            context2.Setup(a => a.Doctores).Returns(dbset.Object);

            var servie = new DoctorService(context2.Object);

            var doctores = servie.GetRetornarListaDoctor("Derek", "Shepherd");
            Assert.AreEqual(1, doctores.Count());
        }
    }
}
