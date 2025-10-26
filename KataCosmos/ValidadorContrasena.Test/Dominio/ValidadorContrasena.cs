using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Test.Enum;

namespace ValidadorContrasena.Test.Dominio
{
    public class Validador
    {
        public bool EsValida(string Contrasena , TipoValidacion tipoValidacion = TipoValidacion.Primera)
        {
            if (Contrasena.Length > 16
                && Contrasena.Any(char.IsUpper) &&
                   Contrasena.Any(char.IsLower) &&
                   Contrasena.Contains('_'))
                return true;

            if (tipoValidacion == TipoValidacion.Segunda)
                return Contrasena.Length > 6 &&
                   Contrasena.Any(char.IsUpper) &&
                   Contrasena.Any(char.IsLower) &&
                   Contrasena.Any(char.IsDigit);

            return Contrasena.Length > 8 &&
                   Contrasena.Any(char.IsUpper) &&
                   Contrasena.Any(char.IsLower) &&
                   Contrasena.Any(char.IsDigit) &&
                   Contrasena.Contains('_');
        }          
    }
}
