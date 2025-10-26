using ValidadorContrasena.Dominio.Enum;

namespace ValidadorContrasena.Dominio.GrupoReglas
{
    public class PrimerGrupoReglas : IContrasenaValidador
    {
        public bool EsValida(string Contrasena)
        {
            return new Validador().EsValida(Contrasena, TipoValidacion.Primera);
        }
    }
}