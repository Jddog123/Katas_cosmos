using ValidadorContrasena.Dominio;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.GrupoReglas;

namespace ValidadorContrasena.Dominio
{
    public class ContrasenaValidadorFactory
    {
        public static IContrasenaValidador CrearFactory(TipoValidacion tipoValidacion)
        {
            if (tipoValidacion == TipoValidacion.Primera)
            {
                return new PrimerGrupoReglas();
            }
            else if (tipoValidacion == TipoValidacion.Segunda)
            {
                return new SegundoGrupoReglas();
            }
            else
            {
                return new TerceroGrupoReglas();
            }
        }
    }
}