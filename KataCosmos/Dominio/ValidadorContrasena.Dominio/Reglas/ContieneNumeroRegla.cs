using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorContrasena.Dominio.Reglas
{
    public class ContieneNumeroRegla : IContrasenaValidador
    {
        public string ErrorMessage => string.Empty;
        public bool EsValida(string contrasena) => contrasena.Any(char.IsDigit);
    }
}
