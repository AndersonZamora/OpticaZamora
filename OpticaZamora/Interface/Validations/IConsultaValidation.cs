using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpticaZamora.Interface.Validations
{
    public interface IConsultaValidation
    {
        //void Validate(Consulta consulta, List<DetalleConsulta> Detalles, ModelStateDictionary modelState);

        bool IsValid();
    }
}
