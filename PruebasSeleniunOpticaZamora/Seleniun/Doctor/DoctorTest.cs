using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun.Doctor
{
    [TestFixture]
    public class DoctorTest
    {
        ChromeDriver Optica = new ChromeDriver();
        [Test]
        public void CliquearDoctorIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Assert.AreEqual("http://localhost:51542/Doctor/List", Optica.Url);//Para ver si la url es la misma que abre chrome
            Optica.Close();
        }
        [Test]
        public void MostrarPantallaagregarDoctorIsOK()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            var listadoctor = Optica.FindElementById("doctorlistaLink");
            Assert.IsNotNull(listadoctor);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
        [Test]
        public void AgregarDoctorIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("23090000");
            Optica.FindElementById("doctorCodigo").SendKeys("178790");
            Optica.FindElementById("doctorNombres").SendKeys("Romero");
            Optica.FindElementById("doctorApellidos").SendKeys("Meza Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("989900099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Romero");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****881100000");
            Optica.FindElementById("doctroGuardar").Click();
            Assert.IsTrue(Optica.Url.EndsWith("/Doctor/List"));//en que url quiero que termine
            Optica.Close();
        }
        [Test]
        public void ValidarFormatoDNIDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("MMMMMMMMMM");
            Optica.FindElementById("doctorCodigo").SendKeys("135790");
            Optica.FindElementById("doctorNombres").SendKeys("Renato");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****881100000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();

        }
        [Test]
        public void ValidarCantidadnumerosDNIDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("123456789000");
            Optica.FindElementById("doctorCodigo").SendKeys("135790");
            Optica.FindElementById("doctorNombres").SendKeys("Renato");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1111");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarDNIUnicoDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("23090000");
            Optica.FindElementById("doctorCodigo").SendKeys("135790");
            Optica.FindElementById("doctorNombres").SendKeys("Renato");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****881100000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarCodigoUnicoDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("178790");
            Optica.FindElementById("doctorNombres").SendKeys("Renato");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****111100000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarFormatoCodigoDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("...***");
            Optica.FindElementById("doctorNombres").SendKeys("Renato");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1111");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcantidaddigitosCodigoDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("nnnnnn90");
            Optica.FindElementById("doctorNombres").SendKeys("Renato");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1111000000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarformatoNombreDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("090909");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1111000000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcampollenoNombreDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendez Carlez");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1111000000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcampollenoApellidoDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****111100000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarformatoApellidoDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("0909888977");
            Optica.FindElementById("doctorCelular").SendKeys("980000099");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1111000000");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcampollenocelularDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1110000001");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarformatocelularDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("mkmkmkmk");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****110000011");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcantidaddigitoscelularDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("98778780067");
            Optica.FindElementById("doctorEspecialidad").SendKeys("Oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****1110000001");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarformatoespecialidadDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("987787800");
            Optica.FindElementById("doctorEspecialidad").SendKeys("1234");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****111000001");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcampollenoespecialidadDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("987787800");
            Optica.FindElementById("doctorEspecialidad").SendKeys("");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("ssss*****110000011");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarcampollenopasswordDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("987787800");
            Optica.FindElementById("doctorEspecialidad").SendKeys("oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
        [Test]
        public void ValidarformatopasswordDoctor()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("doctorLink").Click();
            Optica.FindElementById("TipoDocumento").SendKeys("DNI");
            Optica.FindElementById("doctorNumeroDocumento").SendKeys("48000009");
            Optica.FindElementById("doctorCodigo").SendKeys("123450");
            Optica.FindElementById("doctorNombres").SendKeys("Renan");
            Optica.FindElementById("doctorApellidos").SendKeys("Melendes Flores");
            Optica.FindElementById("doctorCelular").SendKeys("987787800");
            Optica.FindElementById("doctorEspecialidad").SendKeys("oftalmologo");
            Optica.FindElementById("Estado").SendKeys("Activo");
            Optica.FindElementById("doctorUsername").SendKeys("Renato");
            Optica.FindElementById("doctorPassword").SendKeys("aaaa***22");
            Optica.FindElementById("doctroGuardar").Click();
            var inputdni = Optica.FindElementById("doctorNumeroDocumento");
            Assert.IsNotNull(inputdni);
            Optica.Close();
        }
    }
}
