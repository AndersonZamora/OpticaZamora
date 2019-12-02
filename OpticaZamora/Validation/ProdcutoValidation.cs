using OpticaZamora.DB;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace OpticaZamora.Validation
{
    public class ProdcutoValidation : IProdcutoValidation
    {
        private ModelStateDictionary modelState;
        readonly IValidarCampos ValidarCampos;
        readonly OpticaContext Context;
      
        public ProdcutoValidation(IValidarCampos ValidarCampos, OpticaContext Context)
        {
            this.ValidarCampos = ValidarCampos;
            this.Context = Context;
        }

        public bool IsValid()
        {
            return modelState.IsValid;
        }
        public void Validate(Producto producto, ModelStateDictionary modelState)
        {
            this.modelState = modelState;
            try
            {
                ValidarCodigo(producto);
                ValidarNombre(producto);
                ValidarPrecio(producto);
                ValidarStock(producto);
                ValidarDescripcion(producto);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
           
        }
        public void ValidateUpdate(Producto producto, ModelStateDictionary modelState)
        {
            var id = producto.IdProducto;
            var produc = Context.Productos.Where(o => o.IdProducto == id);

            this.modelState = modelState;
            try
            {
                if(!produc.Any(o => o.CodigoProducto == producto.CodigoProducto))
                    ValidarCodigo(producto);

                if(!produc.Any(o => o.Nombre == producto.Nombre))
                    ValidarNombre(producto);

                if(!produc.Any(o => o.Precio == producto.Precio))
                    ValidarPrecio(producto);

                if(!produc.Any(o => o.Stock == producto.Stock))
                    ValidarStock(producto);
                if (!produc.Any(o => o.Descripcion == producto.Descripcion))
                    ValidarDescripcion(producto);
            }
            catch (Exception ex){
                ex.ToString();
            }

        }
        void ValidarCodigo(Producto producto)
        {
            var produc = Context.Productos;

            if (string.IsNullOrEmpty(producto.CodigoProducto))
                modelState.AddModelError("CodigoProducto", "El Codigo de producto es Obligatorio");

            if (producto.CodigoProducto.Contains(" "))
                modelState.AddModelError("CodigoProducto", "Ingrese un Codigo Valido");

            if (string.IsNullOrWhiteSpace(producto.CodigoProducto))
                modelState.AddModelError("CodigoProducto", "Ingrese un Codigo Valido");

            if (producto.CodigoProducto.Length > 15 || producto.CodigoProducto.Length < 6)
                modelState.AddModelError("CodigoProducto", "Ingrese solo 15 caracteres (numeros o letras)");

            if (!ValidarCampos.validarCaractes(producto.CodigoProducto))
                modelState.AddModelError("CodigoProducto", "Ingrese un Codigo Valido");

            if (produc.Any(o => o.CodigoProducto == producto.CodigoProducto))
                modelState.AddModelError("CodigoProducto", "Ya existe un producto con este codido");
        }
        void ValidarNombre(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre))
                modelState.AddModelError("Nombre", "El Nombre es Obligatorio");

            if (!ValidarCampos.validarLetras2(producto.Nombre))
                modelState.AddModelError("Nombre", "Solo ingrese caracteres alfabeticos");
            if (producto.Nombre.Length > 30)
                modelState.AddModelError("Nombre", "Ingrese un nombre valido");

            if (producto.Nombre.Length < 4)
                modelState.AddModelError("Nombre", "Nombre Invalido (Ingrese Minimo 4 caracteres alfabeticos)");
        }
        void ValidarPrecio(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Precio))
                modelState.AddModelError("Precio", "El Precio es Obligatorio");

            if (producto.Precio.Contains(" "))
                modelState.AddModelError("Precio", "Ingrese un Precio es valido");

            if (string.IsNullOrWhiteSpace(producto.Precio))
                modelState.AddModelError("Precio", "Ingrese un Precio es valido");

            if (!ValidarCampos.ValidarPrecio(producto.Precio))
                modelState.AddModelError("Precio", "Formato incorecto");

            if (!ValidarCampos.Precio(producto.Precio))
                modelState.AddModelError("Precio", "Se aceptan valores desde  S/ 5.00  a 2000.00 Soles");
        }
        void ValidarStock(Producto producto)
        {
            if(producto.Stock <= 0)
                modelState.AddModelError("Stock", "El numero de Stock no puede ser cero");
            
            if(!ValidarCampos.ValidarStock(producto.Stock))
                modelState.AddModelError("Stock", "Ingrese Solo Numeros");
        }
        void ValidarDescripcion(Producto producto)
        {
            if(String.IsNullOrEmpty(producto.Descripcion))
                modelState.AddModelError("Descripcion", "Este Campo es obligatorio");

            if (!ValidarCampos.validarCaractes(producto.Descripcion))
                modelState.AddModelError("Descripcion", "Nombre Invalido Ingrese solo caracteres alfabeticos o Numericos");

            if (producto.Descripcion.Length > 400)
                modelState.AddModelError("Descripcion", "Se perminten hasta 400 letras");
        }
    }
}