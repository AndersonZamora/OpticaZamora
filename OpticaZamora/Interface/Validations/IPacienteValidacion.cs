using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpticaZamora.Interface.Validations
{
    public interface IPacienteValidacion
    {
        void validate(Paciente paciente, ModelStateDictionary modelState);
        void validateUpdate(Paciente paciente, ModelStateDictionary modelState);

        bool IsValid();
    }
}
