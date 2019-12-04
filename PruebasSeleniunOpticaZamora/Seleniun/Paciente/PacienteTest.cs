using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun.Paciente
{
    [TestFixture]
    public class PacienteTest
    {
        ChromeDriver Optica = new ChromeDriver();
        [Test]
        public void CliquearPacienteIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Assert.AreEqual("http://localhost:51542/Patient/List", Optica.Url);//Para ver si la url es la misma que abre chrome
            Optica.Close();
        }
        [Test]
        public void MostrarPantallaagregarPacienteIsOK()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            var listapaciente = Optica.FindElementById("pacientelistaLink");
            Assert.IsNotNull(listapaciente);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
        [Test]
        public void AgregarPacienteIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            // Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("72793490");
            Optica.FindElementById("pacienteNombres").SendKeys("Yusley");
            Optica.FindElementById("pacienteApellidos").SendKeys("Sanchez Valderrama");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("yulei@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("FEMENINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("Jr San Juan Cajamarca Cajamarca 645");
            Optica.FindElementById("pacienteCelular").SendKeys("987656534");
            Optica.FindElementById("pacienteGuardar").Click();
            Assert.IsTrue(Optica.Url.EndsWith("/Patient/List"));//en que url quiero que termine
            Optica.Close();

        }

        [Test]
        public void ValidarformatoDNIPaciente()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("mmmm");
            Optica.FindElementById("pacienteNombres").SendKeys("Fabri");
            Optica.FindElementById("pacienteApellidos").SendKeys("Soto Soto");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("fabriiii@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("Jr San Juan Cajamarca Cajamarca 680");
            Optica.FindElementById("pacienteCelular").SendKeys("989651534");
            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();

        }
        [Test]
        public void ValidarformatoDireccion()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("72793623");
            Optica.FindElementById("pacienteNombres").SendKeys("Merly");
            Optica.FindElementById("pacienteApellidos").SendKeys("Paz Soto");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("merly@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("999999");
            Optica.FindElementById("pacienteCelular").SendKeys("948193456");
            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
        [Test]
        public void ValidarDNIUnico()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("72793623");
            Optica.FindElementById("pacienteNombres").SendKeys("mariana");
            Optica.FindElementById("pacienteApellidos").SendKeys("Sanchez Vasquez");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("mariana@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("Jr San Juan Cajamarca Cajamarca 8909");
            Optica.FindElementById("pacienteCelular").SendKeys("98768934");
            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
        [Test]
        public void ValidarformatoCelularPaciente()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("26676767");
            Optica.FindElementById("pacienteNombres").SendKeys("Fabri");
            Optica.FindElementById("pacienteApellidos").SendKeys("Soto Soto");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("fabriiii@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("Jr San Juan Cajamarca Cajamarca 680");
            Optica.FindElementById("pacienteCelular").SendKeys("mmnnbbbvv");

            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();

        }
        [Test]
        public void ValidarCelularPacienteUnico()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("26676767");
            Optica.FindElementById("pacienteNombres").SendKeys("Fabri");
            Optica.FindElementById("pacienteApellidos").SendKeys("Soto Soto");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("fabriiii@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("Jr San Juan Cajamarca Cajamarca 680");
            Optica.FindElementById("pacienteCelular").SendKeys("987656534");
            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();

        }

        [Test]
        public void ValidarformatodecorreoPaciente()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("26676767");
            Optica.FindElementById("pacienteNombres").SendKeys("Fabri");
            Optica.FindElementById("pacienteApellidos").SendKeys("Soto Soto");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("fabriiicom");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("Jr San Juan Cajamarca Cajamarca 680");
            Optica.FindElementById("pacienteCelular").SendKeys("900656534");
            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();

        }
        [Test]
        public void AgregarPacienteNoesOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("pacienteLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("pacienteNumeroDocumento").SendKeys("72793488");
            Optica.FindElementById("pacienteNombres").SendKeys("Fabricio");
            Optica.FindElementById("pacienteApellidos").SendKeys("Sanchez Soto");
            //   chrome.FindElementById("myRange").SendKeys("20");
            Optica.FindElementById("pacienteCorreo").SendKeys("fabri@gmail.com");
            Optica.FindElementById("TipoGenero").SendKeys("MASCULINO");
            Optica.FindElementById("pacienteDireccion").SendKeys("999999");
            Optica.FindElementById("pacienteCelular").SendKeys("987654534");
            Optica.FindElementById("pacienteGuardar").Click();
            var inputdni = Optica.FindElementById("pacienteNumeroDocumento");
            Assert.IsNotNull(inputdni);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
    }
}
