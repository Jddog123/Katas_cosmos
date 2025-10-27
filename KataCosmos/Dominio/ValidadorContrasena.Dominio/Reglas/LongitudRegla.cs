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

        public string ErrorMessage => _minimoLongitud == 6 ? "Debe tener mas de 6 caracteres" : "Debe tener mas de 8 caracteres";

        public bool EsValida(string contrasena) => contrasena.Length > _minimoLongitud;
    }
}
