using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpticaZamora.Interface.Validations
{
    public interface ICategoriaValidation
    {
        void Validate(Categoria categoria, ModelStateDictionary modelState);
        void ValidateUpdate(Categoria categoria, ModelStateDictionary modelState);
        bool IsValid();
    }
}
