using Moq;
using NUnit.Framework;
using OpticaZamora.Controllers;
using OpticaZamora.Interface;
using OpticaZamora.Interface.Managers;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebasUnitariasOpticaZamora.Controller.Login
{ 
    [TestFixture]
    public class LoginControllerTest
    {
        [Test]
        public void DebePoderIniciarSesionSiElRolEsSys(){
            bool valor = true;
            var user = new Sys();
            user.IdUsuario = "1111";
            user.Username = "Anderson";
            user.Password = "12345678";
            user.Rol = "Sys";

            var LoginService = new Mock<ILoginService>();
            LoginService.Setup(o => o.ObtenerUsuario(user)).Returns(user);

            var SessionManager = new Mock<ISessionManager>();
            SessionManager.Setup(o => o.SetIdUsuario(user.IdUsuario));
            SessionManager.Setup(o => o.SetNombreUsuario(user.Name));
            SessionManager.Setup(o => o.AutenticacionUsername(user.Name, valor));

            var controlle = new LoginController(LoginService.Object, SessionManager.Object);
            controlle.ControllerContext = MockControllerContext();

            var redirect = controlle.Signin(user, null);
            Assert.IsInstanceOf<RedirectToRouteResult>(redirect);
            Assert.IsNotInstanceOf<ViewResult>(redirect);
        }
        [Test]
        public void NoDebePoderIniciarSesionSielRolEsDistintoDeSys()
        {
            bool valor = true;
            var user = new Sys();
            user.IdUsuario = "1111";
            user.Username = "Anderson";
            user.Password = "12345678";
            user.Rol = "Doctor";

            var LoginService = new Mock<ILoginService>();
            LoginService.Setup(o => o.ObtenerUsuario(user)).Returns(user);

            var SessionManager = new Mock<ISessionManager>();
            SessionManager.Setup(o => o.SetIdUsuario(user.IdUsuario));
            SessionManager.Setup(o => o.SetNombreUsuario(user.Name));
            SessionManager.Setup(o => o.AutenticacionUsername(user.Name, valor));

            var controlle = new LoginController(LoginService.Object, SessionManager.Object);
            controlle.ControllerContext = MockControllerContext();
            var redirect = controlle.Signin(user, null);
            Assert.IsInstanceOf<ViewResult>(redirect);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(redirect);

        }
        public ControllerContext MockControllerContext()
        {
            var controllerContext = new Mock<ControllerContext>();
            var httpContext = new Mock<HttpContextBase>();
            controllerContext.Setup(o => o.HttpContext).Returns(httpContext.Object);
            return controllerContext.Object;
        }
    }
}
