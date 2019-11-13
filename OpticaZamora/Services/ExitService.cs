using OpticaZamora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Mvc;
using OpticaZamora.DB;
using OpticaZamora.Managers;

namespace OpticaZamora.Services
{
    public class ExitService : IExitService
    {
        [Authorize]
        public void logOff()
        {
            FormsAuthentication.SignOut();
            
        }
    }
}