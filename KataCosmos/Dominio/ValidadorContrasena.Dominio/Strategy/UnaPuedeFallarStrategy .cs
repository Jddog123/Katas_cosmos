using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Dominio.Result;

namespace ValidadorContrasena.Dominio.Strategy
{
    public class UnaPuedeFallarStrategy : IValidacionStrategy
    {
        public ContrasenaValidadorResultado Validar(List<IContrasenaValidador> reglas, string contrasena)
        {
            var errores = reglas.Where(r => !r.EsValida(contrasena)).Select(r => r.ErrorMessage).ToList();
            
            if (errores.Count > 1)
                return new ContrasenaValidadorResultado(errores);

            return new ContrasenaValidadorResultado(new List<string>());
        }
    }
}
