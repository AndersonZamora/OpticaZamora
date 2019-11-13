using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace OpticaZamora.Interface.Validations
{
    public interface IExpedienteValidation
    {
        void Validate(Expediente expediente, ModelStateDictionary modelState);
        bool IsValid();
    }
}
