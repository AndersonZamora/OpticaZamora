using Moq;
using NUnit.Framework;
using OpticaZamora.DB;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using OpticaZamora.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebasUnitariasOpticaZamora
{
    [TestFixture]
    public class ValidarCamposTest
    {
        [Test]
        public void DebeValidarQueSeanSoloSeaLetras()
        {   
            string Nombre = "CategoriaC";
            var validar = new ValidarCampos();
            var estado = validar.ValidarNombreExpreciones(Nombre);
            Assert.AreEqual(true, estado);
            Assert.AreNotEqual(false, estado);
        }
        [Test]
        public void DebeValidarQueNoseanNumeros()
        {

            string Nombre = "3333333";
            var validar = new ValidarCampos();
            var estado = validar.ValidarNombreExpreciones(Nombre);
            Assert.AreEqual(false, estado);
            Assert.AreNotEqual(true, estado);
        }
        [Test]
        public void DebeValidarQueNoseanCaracteresEspeciales()
        {

            string Nombre = "#$%,&/)(="; 
            var validar = new ValidarCampos();

            var estado = validar.ValidarNombreExpreciones(Nombre);
            Assert.AreEqual(false, estado);
            Assert.AreNotEqual(true, estado);
        }
        [Test]
        public void DebeValidarQueSoloSeanNumeros()
        { 
            string numero = "333333";
            var validar = new ValidarCampos();

            var estado = validar.validarnUMEROS(numero);
            Assert.AreEqual(true, estado);
            Assert.AreNotEqual(false, estado);
        }
    }
}
