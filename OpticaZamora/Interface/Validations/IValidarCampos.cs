using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaZamora.Interface.Validations
{
    public interface IValidarCampos
    {
        bool validarCaractes(string numString);
        bool validarnUMEROS(string numString);
        bool validarUnaPalabra(string numString);
        bool validarLetras(string numString);
        bool validarLetras2(string numString);
        int validarEdad(string edad);
        Boolean ValidarEmail(String email);
        Boolean ValidarPrecio(String precio);
        Boolean Precio(string precio);
        Boolean ValidarNombreExpreciones(String nombre);
        Boolean ValidarStock(int nombre);
        Boolean ValidarDireccion(String direccion);
    }
}
