using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun
{
    [TestFixture]
    public class OpticaTest
    {

    }
    //{
    //    ChromeDriver Optica = new ChromeDriver();
    //    [Test]
    //    public void TestHomePega()
    //    {
           
    //        Optica.Url = Global.URL;
            
    //        //Assert.IsTrue(Optica.Url.Contains(""));
    //        Assert.IsTrue(Optica.PageSource.Contains("Login"));
    //        Optica.Close();
    //    }
    //    [Test]
    //    public void TesLoginPega()
    //    {
    //        Optica.Url = Global.URL;
    //        Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
    //        Optica.FindElementById("passwordLogin").SendKeys("12345678");
    //        Optica.FindElementById("Login").Click();
    //        Assert.IsTrue(Optica.Url.EndsWith("/Optica"));
    //        Optica.Close();
    //    }
    //    [Test]
    //    public void TesPacientePega()
    //    {
    //        Optica.Url = Global.URL;
    //        Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
    //        Optica.FindElementById("passwordLogin").SendKeys("12345678");
    //        Optica.FindElementById("Login").Click();

    //        Optica.FindElementById("pacienteLink").Click();
    //        Optica.FindElementById("agregarpacienteLink").Click();
    //        Optica.FindElementById("TipoDocumento").SendKeys("DNI");
    //        Optica.FindElementById("pacienteNumeroDocumento").SendKeys("359E75329");
    //        Optica.FindElementById("pacienteNombres").SendKeys("$$$$$$");
    //        Optica.FindElementById("pacienteApellidos").SendKeys("Coral  r");

    //        //Optica.FindElementById("myRange").SendKeys("4");

    //        Optica.FindElementById("pacienteCorreo").SendKeys("aaaaaaaa");
    //        Optica.FindElementById("TipoGenero").SendKeys("Masculino");
    //        Optica.FindElementById("pacienteDireccion").SendKeys("4444444444444");
    //        Optica.FindElementById("pacienteCelular").SendKeys("ddddddd");
    //        Optica.FindElementById("pacienteGuardar").Click();

    //        Assert.IsTrue(Optica.Url.EndsWith("/Save"));
    //        //Optica.Close();
    //    }
    //    [Test]
    //    public void TesDoctorPega()
    //    {
    //        Optica.Url = Global.URL;
    //        Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
    //        Optica.FindElementById("passwordLogin").SendKeys("12345678");
    //        Optica.FindElementById("Login").Click();

    //        Optica.FindElementById("doctorLink").Click();
    //        Optica.FindElementById("doctorLink").Click();

    //        Optica.FindElementById("TipoDocumento").SendKeys("DNI");
    //        Optica.FindElementById("doctorNumeroDocumento").SendKeys("12385764");
    //        Optica.FindElementById("doctorCodigo").SendKeys("5tsjr5");
    //        Optica.FindElementById("doctorNombres").SendKeys("Anderson B");
    //        Optica.FindElementById("doctorApellidos").SendKeys("Zamora");
    //        Optica.FindElementById("doctorCelular").SendKeys("964754346");
    //        Optica.FindElementById("doctorEspecialidad").SendKeys("Ojos");
    //        Optica.FindElementById("Estado").SendKeys("Inactivo");
    //        Optica.FindElementById("doctorUsername").SendKeys("Lal");
    //        Optica.FindElementById("doctorPassword").SendKeys("4857fhwe5436785");
    //        Optica.FindElementById("doctroGuardar").Click();

    //        Assert.IsTrue(Optica.Url.EndsWith("/Doctor"));
    //        Optica.Close();
    //    }
    //    [Test]
    //    public void TesProductoPega()
    //    {
    //        Optica.Url = Global.URL;
    //        Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
    //        Optica.FindElementById("passwordLogin").SendKeys("12345678");
    //        Optica.FindElementById("Login").Click();

    //        Optica.FindElementById("productoLink").Click();
    //        Optica.FindElementById("agregarpacienteLink").Click();

    //        Optica.FindElementById("CodigoProducto").SendKeys("74ufnss");
    //        Optica.FindElementById("nombreProducto").SendKeys("  ");
    //        Optica.FindElementById("PrecioProducto").SendKeys("50000000000000");
    //        Optica.FindElementById("StockProducto").SendKeys("re");
    //        Optica.FindElementById("descripcionProducto").SendKeys("s");
    //        Optica.FindElementByClassName("select2-selection__arrow").Click();
    //        Optica.FindElementByClassName("select2-search__field").SendKeys("Mujer");
    //        Optica.FindElementByClassName("select2-results__option").Click();
    //        Optica.FindElementById("Guardar").Click();

    //        Assert.IsTrue(Optica.Url.EndsWith("/List"));
    //        Optica.Close();
    //    }
    //    [Test]
    //    public void TesCategoriaPage()
    //    {
    //        Optica.Url = Global.URL;
    //        Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
    //        Optica.FindElementById("passwordLogin").SendKeys("12345678");
    //        Optica.FindElementById("Login").Click();

    //        Optica.FindElementById("CategoriasLink").Click();
    //        Optica.FindElementById("agregarpacienteLink").Click();
    //        Optica.FindElementById("nombreProducto").SendKeys("#4yh$");
    //        Optica.FindElementById("guardar").Click();

    //        Assert.IsTrue(Optica.Url.EndsWith("/List"));
    //        Optica.Close();
    //    }
        
    //}
}
