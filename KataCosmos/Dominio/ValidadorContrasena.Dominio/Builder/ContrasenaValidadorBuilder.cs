using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.Reglas;

namespace ValidadorContrasena.Dominio.Builder
{
    public class ContrasenaValidadorBuilder
    {
        private readonly List<IContrasenaValidador> _reglas = new();

        public ContrasenaValidadorBuilder AgregarRegla(IContrasenaValidador regla)
        {
            _reglas.Add(regla);
            return this;
        }

        public ContrasenaValidador Build(TipoValidacion tipoValidacion = TipoValidacion.Otra) => new ContrasenaValidador(_reglas, tipoValidacion);
    }
}
