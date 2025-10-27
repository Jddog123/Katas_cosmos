using ValidadorContrasena.Dominio.Result;

namespace ValidadorContrasena.Dominio
{
    public interface IValidacionStrategy
    {
        ContrasenaValidadorResultado Validar(List<IContrasenaValidador> reglas, string contrasena);
    }
}