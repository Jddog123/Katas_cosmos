namespace ValidadorContrasena.Dominio.Result
{
    public class ContrasenaValidadorResultado
    {
        public bool EsValida => !Errores.Any();
        public List<string> Errores { get; }

        public ContrasenaValidadorResultado(List<string> errores)
        {
            Errores = errores;
        }
    }
}
