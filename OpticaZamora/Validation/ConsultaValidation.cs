using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Interface.Validations;
using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticaZamora.Validation
{
    public class ConsultaValidation 
    {
        private ModelStateDictionary modelState;
        private IProdcutoValidation ValidationProducto;
        OpticaContext Context = new OpticaContext();
     
        public ConsultaValidation(IProdcutoValidation ValidationProducto)
        {
            this.ValidationProducto = ValidationProducto;
        }
        public bool IsValid()
        {
            return modelState.IsValid;
        }

        //public void Validate(Consulta consulta, List<DetalleConsulta> Detalles, ModelStateDictionary modelState)
        //{
        //    this.modelState = modelState;

        //    if (string.IsNullOrEmpty(consulta.DEsfera))
        //        modelState.AddModelError("DEsfera", "Este campo es obligatorio");

        //    if (string.IsNullOrEmpty(consulta.DCilindro))
        //        modelState.AddModelError("DCilindro", "Este campo es obligatorio");

        //    if (string.IsNullOrEmpty(consulta.DEje))
        //        modelState.AddModelError("DEje", "Este campo es obligatorio");

        //    if (string.IsNullOrEmpty(consulta.IEsfera))
        //        modelState.AddModelError("IEsfera", "Este campo es obligatorio");

        //    if (string.IsNullOrEmpty(consulta.ICilindro))
        //        modelState.AddModelError("ICilindro", "Este campo es obligatorio");

        //    if (string.IsNullOrEmpty(consulta.IEje))
        //        modelState.AddModelError("IEje", "Este campo es obligatorio");


        //    if (string.IsNullOrEmpty(consulta.PacienteId))
        //        modelState.AddModelError("PacienteId", "Seleccione un Paciente");

        //    if (string.IsNullOrEmpty(consulta.DoctorId))
        //        modelState.AddModelError("DoctorId", "Seleccione un Doctor");

        //    if (string.IsNullOrEmpty(consulta.ProductoId))
        //        modelState.AddModelError("ProductoId", "Seleccione un Producto");

        //    if (string.IsNullOrEmpty(consulta.Diagnostico))
        //        modelState.AddModelError("Diagnostico", "Ingrese un Comentario");

           
           
          
        //}
    }
}
//Detalles.ForEach(a =>
//{
//    var r = 
//});
