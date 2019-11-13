using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> GetRetornarListasPaciente(string titulo);
        Paciente GetRetornarPaciente(string IdPaciente);
        void AddPaciente(Paciente paciente);
        Paciente PacienteModificar(string IdPaciente);
        void UpdatePaciente(Paciente paciente);
        void LogOff();

    }
}
