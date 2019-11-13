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
    public class PacienteServiceTest
    {
        [Test]
        public void DebeGetRetornarListaPacientesCuandoCriterioNull()
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

            var paciente = service.GetRetornarListasPaciente("Coral");
            Assert.AreEqual(1, paciente.Count());
        }
    }
}
