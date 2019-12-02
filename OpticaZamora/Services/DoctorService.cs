using OpticaZamora.DB;
using OpticaZamora.Interface;
using OpticaZamora.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace OpticaZamora.Services
{
    public class DoctorService : IDoctorService
    {
     
        readonly OpticaContext Context;
   
        public DoctorService(OpticaContext Context)
        {
            this.Context = Context;
        }
        [Authorize]
        public bool AddDoctor(Doctor doctor)
        {
            Context.Doctores.Add(doctor);
            Context.SaveChanges();
            return true;
        }
        [Authorize]
        public Doctor DoctorModificar(string IdDoctor)
        {
            Doctor doctor = null;
            try
            {
                doctor = Context.Doctores.Where(o => o.IdDoctor == IdDoctor).First();
                return doctor;
            }
            catch (Exception ex) {
                ex.ToString();
            }
            return doctor;
        }
        [Authorize]
        public IEnumerable<Doctor> GetRetornarListaDoctor(string criterio, string criterio2)
        {
            var query = Context.Doctores.AsQueryable();

            if (!string.IsNullOrEmpty(criterio) && !string.IsNullOrEmpty(criterio2))
                query = Context.Doctores.Where(p => p.Nombres == criterio && p.Apellidos == criterio2);
            return query.ToList();
        }
        [Authorize]
        public bool UpdateDoctor(Doctor doctor)
        {
            var DoctorBD = Context.Doctores.Where(o => o.IdDoctor == doctor.IdDoctor).First();
            DoctorBD.Codigo = doctor.Codigo;
            DoctorBD.Nombres = doctor.Nombres;
            DoctorBD.Apellidos = doctor.Apellidos;
            DoctorBD.NumeroDocumento = doctor.NumeroDocumento;
            DoctorBD.Celular = doctor.Celular;
            DoctorBD.Especialidad = doctor.Especialidad;
            DoctorBD.Username = doctor.Username;
            DoctorBD.Password = doctor.Password;
            DoctorBD.Estado = doctor.Estado;
            Context.SaveChanges();
            return true;
        }
        [Authorize]
        public void logOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}