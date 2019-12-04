using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun.Categoria
{
    public class CategoriaTest
    {
        ChromeDriver Optica = new ChromeDriver();
        [Test]

        public void CliquearCategoriaIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("CategoriasLink").Click();
            Assert.AreEqual("http://localhost:51542/Category/List", Optica.Url);//Para ver si la url es la misma que abre chrome
            Optica.Close();
        }
        [Test]
        public void MostrarPantallaagregarCategoriaIsOK()
        {

            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("CategoriasLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            var listacategoria = Optica.FindElementById("ListaCategoriasLink");
            Assert.IsNotNull(listacategoria);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
        [Test]
        public void AgregarCategoriaIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("CategoriasLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("nombreProducto").SendKeys("categorialentedecontacto");
            Optica.FindElementById("guardar").Click();
            Assert.IsTrue(Optica.Url.EndsWith("/Category/List"));//en que url quiero que termine
            Optica.Close();

        }
        [Test]
        public void ValidarcamponombreCategoriaIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("CategoriasLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("nombreProducto").SendKeys("");
            Optica.FindElementById("guardar").Click();
            var inputnombrecateg = Optica.FindElementById("nombreProducto");
            Assert.IsNotNull(inputnombrecateg);
            Optica.Close();

        }
        [Test]
        public void ValidarformatocamponombreCategoriaIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("CategoriasLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("nombreProducto").SendKeys("456783");
            Optica.FindElementById("guardar").Click();
            var inputnombrecateg = Optica.FindElementById("nombreProducto");
            Assert.IsNotNull(inputnombrecateg);
            Optica.Close();
        }
    }
}
