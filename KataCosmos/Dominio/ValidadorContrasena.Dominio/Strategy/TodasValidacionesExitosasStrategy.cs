using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidadorContrasena.Dominio.Result;

namespace ValidadorContrasena.Dominio.Strategy
{
    public class TodasDebenCumplirseStrategy : IValidacionStrategy
    {
        public ContrasenaValidadorResultado Validar(List<IContrasenaValidador> reglas, string contrasena)
        {
            var errores = reglas.Where(r => !r.EsValida(contrasena)).Select(r => r.ErrorMessage).ToList();
            return new ContrasenaValidadorResultado(errores);
        }
    }
}
