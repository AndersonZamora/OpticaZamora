using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpticaZamora.Interface.Validations
{
    public interface IProdcutoValidation
    {
        void Validate(Producto producto, ModelStateDictionary modelState);
        void ValidateUpdate(Producto producto, ModelStateDictionary modelState);

        bool IsValid();
    }
}
