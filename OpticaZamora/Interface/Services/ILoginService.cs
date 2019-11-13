using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface ILoginService
    {
        Sys ObtenerUsuario(Sys sys);
        Doctor ObenerAdmin(Doctor doctor);
    }
}
