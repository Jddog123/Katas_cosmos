namespace ValidadorContrasena.Dominio
{
    public interface IContrasenaValidador
    {
        bool EsValida(string contrasena);
    }
}