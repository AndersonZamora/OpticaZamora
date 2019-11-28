using OpticaZamora.Interface.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
namespace OpticaZamora.Managers
{
    public class SessionManager : ISessionManager
    {
        HttpSessionState Session;
     
        public void SetNombreUsuario(string Name)
        {
            Session = HttpContext.Current.Session;
            Session["Name"] = Name;
          
        }
        public void SetIdUsuario(string IdUsuario)
        {
            Session = HttpContext.Current.Session;
            Session["IdUsuario"] = IdUsuario;
        }

        public void AutenticacionUsername(String Username, bool valor)
        {
            FormsAuthentication.SetAuthCookie(Username, valor);
        }

       
    }
}