using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Dominio.Enum;

namespace ValidadorContrasena.Dominio
{
    public class ContrasenaValidador
    {
        private readonly List<IContrasenaValidador> _reglas;

        public ContrasenaValidador(IEnumerable<IContrasenaValidador> reglas)
        {
            _reglas = reglas.ToList();
        }

        public bool EsValida(string contrasena)
        {
            foreach (var regla in _reglas)
                if (!regla.EsValida(contrasena)) return false;
            return true;
        }
    }
}
