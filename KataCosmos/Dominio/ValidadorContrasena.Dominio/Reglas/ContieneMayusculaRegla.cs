using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorContrasena.Dominio.Reglas
{
    public class ContieneMayusculaRegla : IContrasenaValidador
    {
        public string ErrorMessage => "Debe tener al menos una letra mayuscula";

        public bool EsValida(string contrasena) => contrasena.Any(char.IsUpper);
    }
}
