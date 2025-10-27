using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorContrasena.Dominio.Reglas
{
    public class ContieneGuionBajoRegla : IContrasenaValidador
    {
        public bool EsValida(string contrasena) => contrasena.Contains('_');
    }
}
