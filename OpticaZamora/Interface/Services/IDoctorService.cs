﻿using OpticaZamora.Models;
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
        Boolean AddDoctor(Doctor doctor);
        Doctor DoctorModificar(string IdDoctor);
        Boolean UpdateDoctor(Doctor doctor);
        void logOff();
    }

}
