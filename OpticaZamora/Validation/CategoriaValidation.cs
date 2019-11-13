using OpticaZamora.DB;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Validation
{
    public class CategoriaValidation : ICategoriaValidation
    {
        private ModelStateDictionary modelState;
        private IValidarCampos ValidarCampos;
        OpticaContext context = new OpticaContext();
        public CategoriaValidation(IValidarCampos ValidarCampos)
        {
            this.ValidarCampos = ValidarCampos;
        }
        public bool IsValid()
        {
            return modelState.IsValid;
        }

        public void Validate(Categoria categoria, ModelStateDictionary modelState)
        {
            this.modelState = modelState;
            try
            {
                ValidarNombre(categoria);
            }
            catch(Exception e){}
        }

        public void ValidateUpdate(Categoria categoria, ModelStateDictionary modelState)
        {
            var id = categoria.IdCategoria;
            var cate = context.Categorias.Where(o => o.IdCategoria == id);
            this.modelState = modelState;

            try
            {
                var nom = cate.Any(o => o.Nombre == categoria.Nombre);
                if (nom == false)
                    ///validar Nombre
                    ValidarNombre(categoria);

            }catch(Exception e) { }

        }

        void ValidarNombre(Categoria categoria)
        {
            var categ = context.Categorias;
            if (string.IsNullOrEmpty(categoria.Nombre))
                modelState.AddModelError("Nombre", "El Nombre es Obligatorio");

            if (categoria.Nombre == " ")
                modelState.AddModelError("Nombre", "Nombre Invalido");

            if (!ValidarCampos.ValidarNombreExpreciones(categoria.Nombre))
                modelState.AddModelError("Nombre", "Nombre Invalido");

            if (categoria.Nombre.Length > 40 || categoria.Nombre.Length < 4)
                modelState.AddModelError("Nombre", "Nombre Invalido");

            if (categ.Any(o => o.Nombre == categoria.Nombre))
                modelState.AddModelError("Nombre", "Ya Exite Esta Categoria");
        }

    }
}