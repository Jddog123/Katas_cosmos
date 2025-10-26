using System.Text.RegularExpressions;
using ValidadorContrasena.Dominio;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.GrupoReglas;

namespace ValidadorContrasena.Dominio
{
    public class ContrasenaValidadorFactory
    {
        public static IContrasenaValidador CrearFactory(TipoValidacion tipoValidacion = TipoValidacion.Otra)
        {
            return tipoValidacion switch
            {
                TipoValidacion.Primera => new PrimerGrupoReglas(),
                TipoValidacion.Segunda => new SegundoGrupoReglas(),
                TipoValidacion.Tercera => new TerceroGrupoReglas(),
                _ => throw new Exception("No se encontro el grupo de reglas")
            };
        }
    }
}