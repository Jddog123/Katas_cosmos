using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorContrasena.Dominio.Reglas
{
    public class LongitudRegla : IContrasenaValidador
    {
        private readonly int _minimoLongitud;
        public LongitudRegla(int minimoLongitud)
        {
            _minimoLongitud = minimoLongitud;
        }
        public bool EsValida(string contrasena) => contrasena.Length > _minimoLongitud;
    }
}
