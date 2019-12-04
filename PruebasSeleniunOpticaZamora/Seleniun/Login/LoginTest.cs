using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun.Login
{
    [TestFixture]
    public class LoginTest
    {
        ChromeDriver Optica = new ChromeDriver();
        [Test]
        public void LogeoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Assert.IsTrue(Optica.Url.EndsWith("/Optica"));
            Optica.Close();
        }
        [Test]
        public void LogeoIsNoOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("123456789");
            Optica.FindElementById("Login").Click();
            var inputLogin = Optica.FindElementById("UsernameLogin");
            Assert.IsNotNull(inputLogin);
            Optica.Close();
        }
    }
}
