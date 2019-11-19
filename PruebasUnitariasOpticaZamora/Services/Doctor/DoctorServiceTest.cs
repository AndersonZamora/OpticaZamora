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

            var doctores = servie.GetRetornarListaDoctor(null, null);
            Assert.AreEqual(2, doctores.Count());

        }
        [Test]
        public void DebeGetRetornarListaDoctoresCuandoCriterioNoSeaNull()
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

        [Test]
        public void SVDebePoderRetorarUnDeDoctor()
        {
            string id = "ssssss";
            var data = new List<Doctor>
            {
                   new Doctor { Codigo="jfuert", Apellidos="Coral",Celular="11111",
                       IdDoctor ="ssssss",Nombres="Anderson",NumeroDocumento ="4783434",
                       TipoDocumento = TipoDocumento.DNI},

                   new Doctor {Apellidos="GOMEZ MACEDO",Celular="11111",
                       IdDoctor ="ddddd",Nombres="JAVIER ANGEL",
                       NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Doctor>>();
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Doctores).Returns(dbset.Object);

            var service = new DoctorService(context.Object);

            var doctor = service.DoctorModificar(id);

            Assert.IsNotNull(doctor);
            Assert.AreEqual("ssssss", doctor.IdDoctor);
        }
        [Test]
        public void SVNoDebePoderRetorarUnDeDoctor()
        {
            string id = null;
            var data = new List<Doctor> 
            {
                   new Doctor { Codigo="jfuert", Apellidos="Coral",Celular="11111",
                       IdDoctor ="ssssss",Nombres="Anderson",NumeroDocumento ="4783434",
                       TipoDocumento = TipoDocumento.DNI},

                   new Doctor {Apellidos="GOMEZ MACEDO",Celular="11111",
                       IdDoctor ="ddddd",Nombres="JAVIER ANGEL",
                       NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Doctor>>();
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Doctores).Returns(dbset.Object);

            var service = new DoctorService(context.Object);

            var doctor = service.DoctorModificar(id);
            Assert.IsNull(doctor);
        }
        [Test]
        public void SVDebePoderGuadarUnDoctor()
        {
            var data = new List<Doctor>
            { }.AsQueryable();

            var dbset = new Mock<DbSet<Doctor>>();
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Doctores).Returns(dbset.Object);

            var service = new DoctorService(context.Object);

            var doctor = new Doctor
            {
                Apellidos = "Coral",
                Celular = "11111",
                Nombres = "Anderson",
                NumeroDocumento = "4783434",
                TipoDocumento = TipoDocumento.DNI,
            };

            var guardar = service.AddDoctor(doctor);
            Assert.AreEqual(true, guardar);
            Assert.IsTrue(guardar);
        }
        [Test]
        public void SVDebePoderActualizarUnDoctor()
        {
            var data = new List<Doctor>
            {
                    new Doctor {Apellidos="Coral",Celular="11111",IdDoctor="ssssss",Nombres="Anderson",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI},

                   new Doctor {Apellidos="GOMEZ MACEDO",Celular="11111",IdDoctor="ssssss",Nombres="JAVIER ANGEL",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Doctor>>();
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Doctor>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Doctores).Returns(dbset.Object);

            var service = new DoctorService(context.Object);
            var doctor = new Doctor
            {
                Apellidos = "Zamora",
                Celular = "11111",
                IdDoctor = "ssssss",
                Nombres = "Anderson",
                NumeroDocumento = "4783434",
                TipoDocumento = TipoDocumento.DNI
            };
            var estado = service.UpdateDoctor(doctor); 
            Assert.AreEqual(true, estado);
            Assert.IsTrue(estado);
        }
    }
}
