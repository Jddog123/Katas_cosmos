namespace ValidadorContrasena.Dominio
{
    public interface IContrasenaValidador
    {
        string ErrorMessage { get; }
        bool EsValida(string contrasena);
    }
}