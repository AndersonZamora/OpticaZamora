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
    public class PacienteValidacion : IPacienteValidacion
    {
        private ModelStateDictionary modelState;
        private OpticaContext context;
        private IValidarCampos validarCampos;
        public PacienteValidacion(IValidarCampos validarCampos)
        {
            this.validarCampos = validarCampos;
            context = new OpticaContext();
        }
        [Authorize]
        public void validate(Paciente paciente, ModelStateDictionary modelState)
        {
            this.modelState = modelState;
            try
            {
                ///NUMEROS DE DNI
                NUMERODEIDENTIFICACION(paciente);
                ///VALIDAR FORMATO DE CORREO
                VALIDARCORREO(paciente);          
                ///////////////////
                ///Nombres
                VALIDARNOMBRES(paciente);
                ///////////////////////////////
                ///Apellidos
                VALIDARAPELLIDOS(paciente); 
                ///////////////////////
                ///Telefono
                VALIDARTELEFONO(paciente);
                ///////////////////////////
                ///EDAD
                VALIDAREDAD(paciente);
                ///DIRECCION
                VALIDARDIRECCION(paciente);

            }
            catch(Exception) { }
        }
        public void validateUpdate(Paciente paciente, ModelStateDictionary modelState)
        {
            var id = paciente.IdPaciente;
            var paci = context.Pacientes.Where(o => o.IdPaciente == id);
            this.modelState = modelState;

            try
            {
                var numeroIden = paci.Any(o => o.NumeroDocumento == paciente.NumeroDocumento);
                var nombrs = paci.Any(o => o.Nombres == paciente.Nombres);
                var apell = paci.Any(o => o.Apellidos == paciente.Apellidos);
                var edad = paci.Any(o => o.Edad == paciente.Edad);
                var correo = paci.Any(o => o.Correo == paciente.Correo);
                var direcc = paci.Any(o => o.Direccion == paciente.Direccion);
                var numer = paci.Any(o => o.Celular == paciente.Celular);

                if (numeroIden == false)
                    NUMERODEIDENTIFICACION(paciente);
                if (nombrs == false)
                    VALIDARNOMBRES(paciente);
                if (apell == false)
                    VALIDARAPELLIDOS(paciente);
                if (edad == false)
                    VALIDAREDAD(paciente);
                if (correo == false)
                    VALIDARCORREO(paciente);
                if (direcc == false)
                    VALIDARDIRECCION(paciente);
                if (numer == false)
                    VALIDARTELEFONO(paciente);
            }
            catch(Exception) { }
        }
        private void VALIDARDIRECCION(Paciente paciente)
        {
            if(String.IsNullOrEmpty(paciente.Direccion))
              modelState.AddModelError("Direccion", "Este Campo es Obligatorio");

            if(!validarCampos.ValidarDireccion(paciente.Direccion))
                modelState.AddModelError("Direccion", "Ingrese una direccion correcta");
        }
        private void VALIDARCORREO(Paciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Correo))
                modelState.AddModelError("Correo", "El correro es Obligatorio");
            if (!validarCampos.ValidarEmail(paciente.Correo))
                modelState.AddModelError("Correo", "El Ingrese un correro valido (billyjoe@happycompany.com)");
        }
        private void VALIDAREDAD(Paciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Edad))
                modelState.AddModelError("Edad", "La edad es Obligatorio");

            if (validarCampos.validarEdad(paciente.Edad) < 3)
                modelState.AddModelError("Edad", "Ingrese una  edad valida");
        }
        private void VALIDARTELEFONO(Paciente paciente)
        {
            var pcientes = context.Pacientes;

            if (string.IsNullOrEmpty(paciente.Celular))
                modelState.AddModelError("Celular", "El Celular es Obligatorio");

            if (!validarCampos.validarnUMEROS(paciente.Celular))
                modelState.AddModelError("Celular", "Ingrese solo caracteres numericos");

            if (paciente.Celular.Length < 8 || paciente.Celular.Length > 9)
                modelState.AddModelError("Celular", "Ingrese un numero de celular valido");

            if (pcientes.Any(o => o.Celular == paciente.Celular))
                modelState.AddModelError("Celular", "Numero de celular o telefono ya exite asociado a un paciente");
        }
        private void VALIDARAPELLIDOS(Paciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Apellidos))
                modelState.AddModelError("Apellidos", "El Nombre es Obligatorio");


            if (!validarCampos.validarLetras(paciente.Apellidos))
                modelState.AddModelError("Apellidos", "Solo ingrese caracteres alfabeticos");

            if (paciente.Apellidos.Length < 4)
                modelState.AddModelError("Apellidos", "Ingrese un nombre válido");

            if (paciente.Apellidos.Length > 30)
                modelState.AddModelError("Apellidos", "Ingrese un Apellido válido");
        }
        private void VALIDARNOMBRES(Paciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Nombres))
                modelState.AddModelError("Nombres", "El Nombre es Obligatorio");

            if (!validarCampos.validarLetras(paciente.Nombres))
                modelState.AddModelError("Nombres", "Solo ingrese caracteres alfabeticos");

            if (paciente.Nombres.Length < 4)
                modelState.AddModelError("Nombres", "Ingrese un nombre válido");

            if (paciente.Nombres.Length > 30)
                modelState.AddModelError("Nombres", "Ingrese un nombre válido");
        }
        private void NUMERODEIDENTIFICACION(Paciente paciente)
        {
            var pcientes = context.Pacientes;
            if (string.IsNullOrEmpty(paciente.NumeroDocumento))
                modelState.AddModelError("NumeroDocumento", "El Numero de Documento es Obligatorio");

            if (!validarCampos.validarnUMEROS(paciente.NumeroDocumento))
                modelState.AddModelError("NumeroDocumento", "Solo Ingrese numeros");

            if (paciente.NumeroDocumento.Contains(" "))
                modelState.AddModelError("NumeroDocumento", "Ingrese un DNI valido");

            if (paciente.NumeroDocumento.Length > 8 || paciente.NumeroDocumento.Length < 8)
                modelState.AddModelError("NumeroDocumento", "Ingrese solo 8 caracteres numericos");

            if (pcientes.Any(o => o.NumeroDocumento == paciente.NumeroDocumento))
                modelState.AddModelError("NumeroDocumento", "Ya existe un paciente con este Numero de documento");
        }
        public bool IsValid()
        {
            return modelState.IsValid;
        }
    }
}