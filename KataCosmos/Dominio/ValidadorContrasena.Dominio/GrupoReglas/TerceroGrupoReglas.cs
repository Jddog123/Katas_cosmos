using ValidadorContrasena.Dominio.Enum;

namespace ValidadorContrasena.Dominio.GrupoReglas
{
    internal class TerceroGrupoReglas : IContrasenaValidador
    {
        public bool EsValida(string Contrasena)
        {
            return new Validador().EsValida(Contrasena, TipoValidacion.Tercera);
        }
    }
}