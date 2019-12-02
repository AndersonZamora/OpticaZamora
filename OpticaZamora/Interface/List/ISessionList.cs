using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface.List
{
    public interface ISessionList
    {
        
        List<Doctor> SetListaDocotores();
        List<Paciente> SetListaPaciente(string IdPaciente);
        List<Producto> GetProductosDeBaseDeDatos();
        List<Expediente> GetExpedientes(string IdPaciente);
        IEnumerable<Expediente> GetListaExpedientes(string IdPaciente);
    }
}
