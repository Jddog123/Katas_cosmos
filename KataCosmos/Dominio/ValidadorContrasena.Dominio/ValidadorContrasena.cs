using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.Result;

namespace ValidadorContrasena.Dominio
{
    public class ContrasenaValidador
    {
        private readonly List<IContrasenaValidador> _reglas;
        private readonly IValidacionStrategy _strategy;

        public ContrasenaValidador(IEnumerable<IContrasenaValidador> reglas, IValidacionStrategy strategy)
        {
            _reglas = reglas.ToList();
            _strategy = strategy;
        }

        public ContrasenaValidadorResultado EsValida(string contrasena)
        {
            return _strategy.Validar(_reglas, contrasena);
        }
    }
}
