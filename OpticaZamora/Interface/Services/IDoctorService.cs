using OpticaZamora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetRetornarListaDoctor(string criterio,string criterio2);
        void AddDoctor(Doctor doctor);
        Doctor DoctorModificar(string IdDoctor);
        void UpdateDoctor(Doctor doctor);
        void logOff();
    }

}
