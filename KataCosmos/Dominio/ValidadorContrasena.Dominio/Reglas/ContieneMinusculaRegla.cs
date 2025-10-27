using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorContrasena.Dominio.Reglas
{
    public class ContieneMinusculaRegla : IContrasenaValidador
    {
        public string ErrorMessage => "Debe tener al menos una letra minuscula";

        public bool EsValida(string contrasena) => contrasena.Any(char.IsLower);
    }
}
