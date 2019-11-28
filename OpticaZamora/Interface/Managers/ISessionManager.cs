using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface.Managers
{
    public interface ISessionManager
    {
        void SetNombreUsuario(String Name);
        void SetIdUsuario(String IdUsuario);
     
        void AutenticacionUsername(String Username, bool valor);
    }
}
