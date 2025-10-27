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
        private TipoValidacion _tipoValidacion;

        public ContrasenaValidador(IEnumerable<IContrasenaValidador> reglas, TipoValidacion tipoValidacion)
        {
            _reglas = reglas.ToList();
            _tipoValidacion = tipoValidacion;
        }

        public ContrasenaValidadorResultado EsValida(string contrasena)
        {
            var errores = new List<string>();
            foreach (var regla in _reglas)
                if (!regla.EsValida(contrasena) && (_tipoValidacion != TipoValidacion.Cuarta || (_tipoValidacion == TipoValidacion.Cuarta && regla.ErrorMessage != "Debe tener al menos un guion bajo")))
                    errores.Add(regla.ErrorMessage);

            return new ContrasenaValidadorResultado(errores);
        }
    }
}
