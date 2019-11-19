using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticaZamora.Services
{
    
    public class LoginService : ILoginService
    {
        private OpticaContext Context;
        public LoginService(OpticaContext Context)
        {
            this.Context = Context;
        }

        public Doctor ObenerAdmin(Doctor doctor)
        {
            return Context.Doctores.Where(s => s.Username == doctor.Username
                     && s.Password == doctor.Password).FirstOrDefault();
        }

        public Sys ObtenerUsuario(Sys sys)
        {
            return Context.Syss.Where(s => s.Username == sys.Username
                    && s.Password == sys.Password).FirstOrDefault();
        }
    }
}