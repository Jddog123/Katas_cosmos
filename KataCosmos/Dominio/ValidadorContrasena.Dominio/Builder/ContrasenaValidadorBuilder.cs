using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.Reglas;
using ValidadorContrasena.Dominio.Strategy;

namespace ValidadorContrasena.Dominio.Builder
{
    public class ContrasenaValidadorBuilder
    {
        private readonly List<IContrasenaValidador> _reglas = new();
        private IValidacionStrategy _strategy;

        public ContrasenaValidadorBuilder AgregarRegla(IContrasenaValidador regla)
        {
            _reglas.Add(regla);
            return this;
        }

        public ContrasenaValidadorBuilder AgregarStrategy(IValidacionStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        public ContrasenaValidador Build() => new ContrasenaValidador(_reglas, _strategy ?? new TodasDebenCumplirseStrategy());
    }
}
