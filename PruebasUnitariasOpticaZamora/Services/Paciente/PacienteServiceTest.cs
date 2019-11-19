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
    public class PacienteServiceTest
    {
        [Test]
        public void SVDebePoderRetorarUnDePaciente()
        {

            var data = new List<Paciente>
            {
                   new Paciente { Apellidos="Coral",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="Anderson",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino},

                   new Paciente {Apellidos="GOMEZ MACEDO",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ddddd",Nombres="JAVIER ANGEL",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Paciente>>();
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Pacientes).Returns(dbset.Object);

            var service = new PacienteService(context.Object);

            var paciente = service.PacienteModificar("ssssss");

            Assert.IsNotNull(paciente);
            Assert.AreEqual("ssssss", paciente.IdPaciente);
        }

        [Test]
        public void SVDebePoderNoRetorarUnDePaciente()
        { 
            var data = new List<Paciente>
            {
                   new Paciente { Apellidos="Coral",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="Anderson",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino},

                   new Paciente {Apellidos="GOMEZ MACEDO",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ddddd",Nombres="JAVIER ANGEL",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Paciente>>();
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Pacientes).Returns(dbset.Object);

            var service = new PacienteService(context.Object);

            var paciente = service.PacienteModificar("otroId");

            Assert.IsNull(paciente);
        }

        [Test]
        public void SVDebePoderRetorarUnaListaDePacienteCuandoElCriterioSeaNulo()
        {
            string criterio = null;
            var data = new List<Paciente>
            {
                    new Paciente {Apellidos="Coral",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="Anderson",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino},

                   new Paciente {Apellidos="GOMEZ MACEDO",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="JAVIER ANGEL",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Paciente>>();
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Pacientes).Returns(dbset.Object);

            var service = new PacienteService(context.Object);

            var paciente = service.GetRetornarListasPaciente(criterio);

            Assert.IsNotNull(paciente);
            Assert.AreEqual(2, paciente.Count());
        }
        [Test]
        public void SVDebePoderRetorarUnaPacienteCuandoElCriterioNoSeaNulo()
        {
            string criterio = "Anderson";
            var data = new List<Paciente>
            {
                    new Paciente {Apellidos="Coral",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="Anderson",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino},

                   new Paciente {Apellidos="GOMEZ MACEDO",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="JAVIER ANGEL",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Paciente>>();
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Pacientes).Returns(dbset.Object);

            var service = new PacienteService(context.Object);

            var paciente = service.GetRetornarListasPaciente(criterio);

            Assert.IsNotNull(paciente);
            Assert.AreEqual(1, paciente.Count());
        }
        [Test]
        public void SVDebePoderGuadarUnPaciente()
        {
            var data = new List<Paciente>
            {}.AsQueryable();

            var dbset = new Mock<DbSet<Paciente>>();
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Pacientes).Returns(dbset.Object);

            var service = new PacienteService(context.Object);

            var paciente = new Paciente
            {
                Apellidos = "Coral",
                Celular = "11111",
                Correo = "ander@gmail.com",
                Direccion = "jr los andes",
                Edad = "22",
                Nombres = "Anderson",
                NumeroDocumento = "4783434",
                TipoDocumento = TipoDocumento.DNI,
                TipoGenero = Genero.Masculino
            };

            var guardar = service.AddPaciente(paciente);
            Assert.AreEqual(true, guardar);
            Assert.IsTrue(guardar);           
        }
        [Test]
        public void SVDebePoderActualizarUnPaciente()
        { 
            var data = new List<Paciente>
            {
                    new Paciente {Apellidos="Coral",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="Anderson",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino},

                   new Paciente {Apellidos="GOMEZ MACEDO",Celular="11111",Correo="ander@gmail.com",
                    Direccion ="jr los andes",Edad="22",IdPaciente="ssssss",Nombres="JAVIER ANGEL",
                    NumeroDocumento ="4783434",TipoDocumento = TipoDocumento.DNI, TipoGenero = Genero.Masculino}
            }.AsQueryable();

            var dbset = new Mock<DbSet<Paciente>>();
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Provider).Returns(data.Provider);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.Expression).Returns(data.Expression);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbset.As<IQueryable<Paciente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<OpticaContext>();
            context.Setup(a => a.Pacientes).Returns(dbset.Object);

            var service = new PacienteService(context.Object);
            var paciente = new Paciente
            {
                Apellidos = "Zamora",
                Celular = "11111",
                Correo = "ander@gmail.com",
                Direccion = "jr los andes",
                Edad = "22",
                IdPaciente = "ssssss",
                Nombres = "Anderson",
                NumeroDocumento = "4783434",
                TipoDocumento = TipoDocumento.DNI,
                TipoGenero = Genero.Masculino
            };
            var estado = service.UpdatePaciente(paciente);
            Assert.AreEqual(true, estado);
            Assert.IsTrue(estado);
        }
    }
}
