using ValidadorContrasena.Dominio.Enum;

namespace ValidadorContrasena.Dominio.GrupoReglas
{
    public class SegundoGrupoReglas : IContrasenaValidador
    {
        public bool EsValida(string Contrasena)
        {
            return new Validador().EsValida(Contrasena,TipoValidacion.Segunda);
        }
    }
}