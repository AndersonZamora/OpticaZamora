using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpticaZamora.Interface.Validations
{
    public interface IDoctorValidation
    {
        void Validate(Doctor doctor, ModelStateDictionary modelState);
        void ValidateUpdate(Doctor doctor, ModelStateDictionary modelState);
        bool IsValid();
    }
}
