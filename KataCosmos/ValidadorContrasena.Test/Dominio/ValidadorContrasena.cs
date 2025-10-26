using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorContrasena.Test.Dominio
{
    public class Validador
    {
        public string Contrasena { get; private set; }
        public Validador(string contrasena)
        {
            Contrasena = contrasena;
        }
        public bool EsValida()
        {
            return Contrasena.Length == 8 &&
                   Contrasena.Any(char.IsUpper) &&
                   Contrasena.Any(char.IsLower) &&
                   Contrasena.Any(char.IsDigit) &&
                   Contrasena.Contains('_');
        }          
    }
}
