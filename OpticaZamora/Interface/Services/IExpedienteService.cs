using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface IExpedienteService
    {
        IEnumerable<Expediente> GetRetornarListaExpedientes(string tit, string criterio);
        Expediente ExpedientePaciente(string IdPaciente);

        void AddAExpediente(Expediente expediente);
        List<Expediente> GetListaExpedientes(string Id);

        Expediente GetListaExp(string Id);
    }
}
