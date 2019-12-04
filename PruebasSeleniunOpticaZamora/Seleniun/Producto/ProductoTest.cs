using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using PruebasSeleniunOpticaZamora.LinkGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSeleniunOpticaZamora.Seleniun.Producto
{
    [TestFixture]
    public class ProductoTest
    {
        ChromeDriver Optica = new ChromeDriver();
        [Test]
        public void CliquearProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Assert.AreEqual("http://localhost:51542/Product/List", Optica.Url);//Para ver si la url es la misma que abre chrome
            Optica.Close();
        }
        [Test]
        public void MostrarPantallaagregarProductoIsOK()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            var listaproducto = Optica.FindElementById("ListaProductosLink");
            Assert.IsNotNull(listaproducto);//para ver que exista el elemento,esta linea y la anterior
            Optica.Close();
        }
        [Test]
        public void AgregarProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigooooo");
            Optica.FindElementById("nombreProducto").SendKeys("lente de invierno");
            Optica.FindElementById("PrecioProducto").SendKeys("25");
            Optica.FindElementById("StockProducto").SendKeys("20");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerinvierno");
            // Optica.FindElementById("select2-CategoriaAelegir-container").SendKeys("categoria lentes de verano");
            Optica.FindElementById("Guardar").Click();
            Assert.IsTrue(Optica.Url.EndsWith("/Product/List"));//en que url quiero que termine
            Optica.Close();
        }
        [Test]
        public void ValidarcampocodigoProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("");
            Optica.FindElementById("nombreProducto").SendKeys("lente de verano");
            Optica.FindElementById("PrecioProducto").SendKeys("25");
            Optica.FindElementById("StockProducto").SendKeys("20");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();

        }
        [Test]
        public void ValidarcamponombreProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("");
            Optica.FindElementById("PrecioProducto").SendKeys("25");
            Optica.FindElementById("StockProducto").SendKeys("20");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();
        }
        [Test]
        public void ValidarformatocamponombreProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("565656565");
            Optica.FindElementById("PrecioProducto").SendKeys("25");
            Optica.FindElementById("StockProducto").SendKeys("20");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();

        }
        [Test]
        public void ValidarcampoprecioProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("lente de Mujer");
            Optica.FindElementById("PrecioProducto").SendKeys("");
            Optica.FindElementById("StockProducto").SendKeys("20");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();

        }
        [Test]
        public void ValidarformatocampoprecioProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("lente de Mujer");
            Optica.FindElementById("PrecioProducto").SendKeys("mnm");
            Optica.FindElementById("StockProducto").SendKeys("20");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();

        }
        [Test]
        public void ValidarformatocampostockProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("lente de Mujer");
            Optica.FindElementById("PrecioProducto").SendKeys("68");
            Optica.FindElementById("StockProducto").SendKeys("vb");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();

        }
        [Test]
        public void ValidarcampostockProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("lente de Mujer");
            Optica.FindElementById("PrecioProducto").SendKeys("68");
            Optica.FindElementById("StockProducto").SendKeys("0");
            Optica.FindElementById("descripcionProducto").SendKeys("lentemujerverano");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();

        }
        [Test]
        public void ValidarcamposdescripcionProductoIsOk()
        {
            Optica.Url = Global.URL;
            Optica.FindElementById("UsernameLogin").SendKeys("Anderson");
            Optica.FindElementById("passwordLogin").SendKeys("12345678");
            Optica.FindElementById("Login").Click();
            Optica.FindElementById("productoLink").Click();
            Optica.FindElementById("agregarpacienteLink").Click();
            Optica.FindElementById("CodigoProducto").SendKeys("codigoooo");
            Optica.FindElementById("nombreProducto").SendKeys("lente de Mujer");
            Optica.FindElementById("PrecioProducto").SendKeys("68");
            Optica.FindElementById("StockProducto").SendKeys("0");
            Optica.FindElementById("descripcionProducto").SendKeys("");
            Optica.FindElementById("Guardar").Click();
            var inputcodigo = Optica.FindElementById("CodigoProducto");
            Assert.IsNotNull(inputcodigo);
            Optica.Close();
        }
    }
}
