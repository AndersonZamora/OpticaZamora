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
    public class DoctorValidation : IDoctorValidation
    {
        private ModelStateDictionary modelState;
        readonly OpticaContext context;
        readonly IValidarCampos validarCampos;

        public DoctorValidation(IValidarCampos validarCampos, OpticaContext context)
        {
            this.validarCampos = validarCampos;
            this.context = context;
        }
        [Authorize]
        public void Validate(Doctor doctor, ModelStateDictionary modelState)
        { 
            this.modelState = modelState;
            try {
                ValidarNumeroDocumento(doctor);
                ValidarCodigo(doctor);
                ValidarNombres(doctor);
                ValidarApellidos(doctor);
                ValidarCelular(doctor);
                ValidarEspecialidad(doctor);
                ValidarEspecialidad(doctor);
                ValidarPasswor(doctor);
            }
            catch (Exception e){
                e.ToString();
            } 
        }    
        public void ValidateUpdate(Doctor doctor, ModelStateDictionary modelState)
        {
            var id = doctor.IdDoctor;
            var dctor = context.Doctores.Where(o => o.IdDoctor == id);
            this.modelState = modelState;
            try
            {
                if(!dctor.Any(o => o.Codigo == doctor.Codigo))
                    ValidarCodigo(doctor);

                if(!dctor.Any(o => o.NumeroDocumento == doctor.NumeroDocumento))
                    ValidarNumeroDocumento(doctor);

                 if(!dctor.Any(o => o.Nombres == doctor.Nombres))
                    ValidarNombres(doctor);

                if(!dctor.Any(o => o.Apellidos == doctor.Apellidos))
                    ValidarApellidos(doctor);

               if(!dctor.Any(o => o.Celular == doctor.Celular))
                    ValidarCelular(doctor);

                if(!dctor.Any(o => o.Especialidad == doctor.Especialidad))
                    ValidarEspecialidad(doctor);

                if(!dctor.Any(o => o.Username == doctor.Username))
                    ValidarUserName(doctor);

                if(!dctor.Any(o => o.Password == doctor.Password))
                    ValidarPasswor(doctor);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public bool IsValid()
        {
            return modelState.IsValid;
        }
        public void ValidarCodigo(Doctor doctor)
        {
            var dctor = context.Doctores;
            if (string.IsNullOrEmpty(doctor.Codigo))
                modelState.AddModelError("Codigo", "El Codigo es Obligatorio");

            if (doctor.Codigo.Contains(" "))
                modelState.AddModelError("Codigo", "Ingrese un codigo valido");

            if (string.IsNullOrWhiteSpace(doctor.Codigo))
                modelState.AddModelError("Codigo", "Ingrese un codigo valido");

            if (doctor.Codigo.Length > 6 || doctor.Codigo.Length < 6)
                modelState.AddModelError("Codigo", "Ingrese solo 6 caracteres (numeros o letras)");

            if (!validarCampos.validarCaractes(doctor.Codigo))
                modelState.AddModelError("Codigo", "Ingrese Un codigo valido");

            if (dctor.Any(o => o.Codigo == doctor.Codigo))
                modelState.AddModelError("Codigo", "Ya existe un doctor con este codido");
        }
        public void ValidarNumeroDocumento(Doctor doctor)
        {
            var dctor = context.Doctores;
            if (string.IsNullOrEmpty(doctor.NumeroDocumento))
                modelState.AddModelError("NumeroDocumento", "El Numero de Documento es Obligatorio");

            if (!validarCampos.validarnUMEROS(doctor.NumeroDocumento))
                modelState.AddModelError("NumeroDocumento", "Solo Ingrese numeros");

            if (doctor.NumeroDocumento.Contains(" "))
                modelState.AddModelError("NumeroDocumento", "Ingrese un DNI valido");

            if (doctor.NumeroDocumento.Length > 8 || doctor.NumeroDocumento.Length < 8)
                modelState.AddModelError("NumeroDocumento", "Ingrese solo 8 caracteres numericos");

            if (dctor.Any(o => o.NumeroDocumento == doctor.NumeroDocumento))
                modelState.AddModelError("NumeroDocumento", "Ya existe un doctor con este Numero de documento");
        }
        public void ValidarNombres(Doctor doctor)
        {
            if (string.IsNullOrEmpty(doctor.Nombres))
                modelState.AddModelError("Nombres", "El Nombre es Obligatorio");

            if (!validarCampos.validarLetras(doctor.Nombres))
                modelState.AddModelError("Nombres", "Solo ingrese caracteres alfabeticos");

            if (doctor.Nombres.Length < 4)
                modelState.AddModelError("Nombres", "Ingrese un nombre válido");

            if (doctor.Nombres.Length > 30)
                modelState.AddModelError("Nombres", "Ingrese un nombre válido");
        }
        public void ValidarApellidos(Doctor doctor)
        {
          
            if (string.IsNullOrEmpty(doctor.Apellidos))
                modelState.AddModelError("Apellidos", "El Nombre es Obligatorio");

            if (!validarCampos.validarLetras(doctor.Apellidos))
                modelState.AddModelError("Apellidos", "Solo ingrese caracteres alfabeticos");

            if (doctor.Apellidos.Length < 4)
                modelState.AddModelError("Apellidos", "Ingrese un apellido válido");

            if (doctor.Apellidos.Length > 30)
                modelState.AddModelError("Apellidos", "Ingrese un apellido válido");
        }
        public void ValidarCelular(Doctor doctor)
        {
            var dctor = context.Doctores;
            if (string.IsNullOrEmpty(doctor.Celular))
                modelState.AddModelError("Celular", "El Celular es Obligatorio");

            if (!validarCampos.validarnUMEROS(doctor.Celular))
                modelState.AddModelError("Celular", "Ingrese solo caracteres numericos");
            if (doctor.Celular.Length < 8 || doctor.Celular.Length > 9)
                modelState.AddModelError("Celular", "Ingrese un numero de celular valido");

            if (doctor.Celular.Length > 9)
                modelState.AddModelError("Celular", "Ingrese un numero de celular valido");

            if (dctor.Any(o => o.Celular == doctor.Celular))
                modelState.AddModelError("Celular", "Numero de celular o telefono ya exite asociado a un paciente");
        }
        public void ValidarEspecialidad(Doctor doctor)
        {
            if (string.IsNullOrEmpty(doctor.Especialidad))
                modelState.AddModelError("Especialidad", "La Especialidad es Obligatorio");

            if (!validarCampos.validarLetras(doctor.Especialidad))
                modelState.AddModelError("Especialidad", "Solo ingrese caracteres alfabeticos");

            if (doctor.Especialidad.Length > 30)
                modelState.AddModelError("Especialidad", "Resuma su especialidad en maximo 30 caracteres alfabeticos");
        }
        public void ValidarUserName(Doctor doctor)
        {
            var dctor = context.Doctores;
            if (string.IsNullOrEmpty(doctor.Username))
                modelState.AddModelError("Username", "El Nombre de usuario es Obligatorio");

            if (!validarCampos.validarCaractes(doctor.Username))
                modelState.AddModelError("Username", "Nombre de usuario invalido,(Sin espacion ni caracteres especiales)");

            if (doctor.Username.Length < 6)
                modelState.AddModelError("Username", "Minimo 6 caractes numericos o alfabeticos");

            if (doctor.Username.Length > 15)
                modelState.AddModelError("Username", "Maximo 15 caractes numericos o alfabeticos");

            if (dctor.Any(o => o.Username == doctor.Username))
                modelState.AddModelError("Username", "Ya existe un doctor con este Nombre de Usuario");

        }
        public void ValidarPasswor(Doctor doctor)
        {
            if (string.IsNullOrEmpty(doctor.Password))
                modelState.AddModelError("Password", "Ingrese una contraseña");

            if (doctor.Password.Contains(" "))
                modelState.AddModelError("Password", "Ingrese una contraseña sin espacios");

            if (doctor.Password.Length < 8)
                modelState.AddModelError("Password", "Ingrese 6 caracteres como minimo");

            if (doctor.Password.Length < 15)
                modelState.AddModelError("Password", "Maximo 15 caracteres");
        }
       
    }
}
