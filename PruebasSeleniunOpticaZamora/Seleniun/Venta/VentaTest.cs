using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun.Venta
{
    [TestFixture]
    public class VentaTest
    {
        ChromeDriver Optica = new ChromeDriver();
        [Test]
        public void CliquearVentaIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("VentasLink").Click();
            Assert.AreEqual("http://localhost:51542/Optica/Venta", Optica.Url);//Para ver si la url es la misma que abre chrome
            Optica.Close();
        }
        [Test]
        public void MostrarPantallaagregarVentaIsOK()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("VentasLink").Click();
            Optica.FindElementById("linkVenta").Click();
            var listaventa = Optica.FindElementById("AgregarCleinteLink");
            Assert.IsNotNull(listaventa);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
    }
}
