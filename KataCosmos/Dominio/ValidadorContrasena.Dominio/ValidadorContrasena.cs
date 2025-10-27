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

        public ContrasenaValidador(IEnumerable<IContrasenaValidador> reglas)
        {
            _reglas = reglas.ToList();
        }

        public ContrasenaValidadorResultado EsValida(string contrasena)
        {
            var errores = new List<string>();
            foreach (var regla in _reglas)
                if (!regla.EsValida(contrasena))
                    errores.Add(regla.ErrorMessage);

            return new ContrasenaValidadorResultado(errores);
        }
    }
}
