using OpticaZamora.Interface.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;

namespace OpticaZamora.Validation
{
    public class ValidarCampos : IValidarCampos
    {
       
        public bool validarCaractes(string numString)
        {
            char[] charArr = numString.ToCharArray();
            foreach (char cd in charArr)
            {
                if (!char.IsLetterOrDigit(cd) && !char.IsSeparator(cd))
                {
                    return false;
                }
            }
            return true;
        }
        public int validarEdad(string edad)
        {
            string request = edad;
            int result = Int32.Parse(request);
            return result;
        }
        public bool validarLetras(string numString)
        {

            string parte = numString.Trim();
            int count = parte.Count(s => s == ' ');
            if (parte == "")
            {
                return false;
            }
            else if (count > 1)
            {
                return false;
            }
            char[] charArr = parte.ToCharArray();
            foreach (char cd in charArr)
            {
                if (!char.IsLetter(cd) && !char.IsSeparator(cd))
                    return false;
            }
            return true;
        }
        public bool validarLetras2(string numString)
        {

            string parte = numString.Trim();

            int count = parte.Count(s => s == ' ');
            if (parte == "")
            {
                return false;
            }
            else if (count > 3)
            {
                return false;
            }
            char[] charArr = parte.ToCharArray();
            foreach (char cd in charArr)
            {
                if (!char.IsLetter(cd) && !char.IsSeparator(cd))
                    return false;
            }
            return true;
        }
        public bool validarnUMEROS(string numString)
        {
            char[] charArr = numString.ToCharArray();
            foreach (char cd in charArr)
            {
                if (!char.IsNumber(cd))
                    return false;
            }
            return true;
        }
        public bool validarUnaPalabra(string numString)
        {
            char[] charArr = numString.ToCharArray();
            foreach (char cd in charArr)
            {
                if (!char.IsLetter(cd))
                    return false;
            }
            return true;
        }
        public Boolean ValidarEmail(String email)
        {
            String expresion;
           
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.])*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if(Regex.Replace(email,expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public Boolean ValidarDomicilio(String email)
        {
            String expresion;

            expresion = "^.*(?=.*[0-9])(?=.*[a-zA-ZñÑ\\s]).*$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public Boolean ValidarPrecio(String precio)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (!regex.IsMatch(precio))
            {
                return false;
            }
            else{return true;}
        }
        public bool Precio(string precio)
        {
            float val = Convert.ToSingle(precio, CultureInfo.CreateSpecificCulture("en-US"));

            if (val > 2000.00 || val < 5.00)
            {
                return false;
            }
            return true;
        }
        public bool ValidarNombreExpreciones(string nombre)
        {
            String expresion;

            expresion = "[a-zA-ZñÑ\\s]{2,50}";
            if (Regex.IsMatch(nombre, expresion))
            {
                if (Regex.Replace(nombre, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ValidarStock(int nombre)
        {
            string stoc = nombre.ToString();

            String expresion;

            expresion = "[0-9]{1,9}(\\.[0-9]{0,2})?$";
            if (Regex.IsMatch(stoc, expresion))
            {
                if (Regex.Replace(stoc, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ValidarDireccion(string direccion)
        {

            String expresion;

            expresion = "^.*(?=.*[0-9])(?=.*[a-zA-ZñÑ\\s]).*$";
            if (Regex.IsMatch(direccion, expresion))
            {
                if (Regex.Replace(direccion, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}