using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Services
{
    public class ExpedienteValidation : IExpedienteValidation
    {
        public bool IsValid()
        {
            throw new NotImplementedException();
        }
        [Authorize]
        public void Validate(Expediente expediente, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}