using OpticaZamora.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface.Services
{
    public interface IDetalleVenta
    {
        List<DetalleVenta> Ventas();
    }
}
