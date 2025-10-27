using System.Text.RegularExpressions;
using ValidadorContrasena.Dominio;
using ValidadorContrasena.Dominio.Builder;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.Reglas;
using ValidadorContrasena.Dominio.Strategy;

namespace ValidadorContrasena.Dominio
{
    public class ContrasenaValidadorFactory
    {
        public static ContrasenaValidador CrearFactory(TipoValidacion tipoValidacion)
        {
            var builder = new ContrasenaValidadorBuilder();
            switch (tipoValidacion)
            {
                case TipoValidacion.Primera:
                    return builder.AgregarRegla(new LongitudRegla(8))
                        .AgregarRegla(new ContieneMayusculaRegla())
                        .AgregarRegla(new ContieneMinusculaRegla())
                        .AgregarRegla(new ContieneNumeroRegla())
                        .AgregarRegla(new ContieneGuionBajoRegla())
                        .Build();
                case TipoValidacion.Segunda:
                    return builder.AgregarRegla(new LongitudRegla(6))
                        .AgregarRegla(new ContieneMayusculaRegla())
                        .AgregarRegla(new ContieneMinusculaRegla())
                        .AgregarRegla(new ContieneNumeroRegla())
                        .Build();
                case TipoValidacion.Tercera:
                    return builder.AgregarRegla(new LongitudRegla(16))
                        .AgregarRegla(new ContieneMayusculaRegla())
                        .AgregarRegla(new ContieneMinusculaRegla())
                        .AgregarRegla(new ContieneGuionBajoRegla())
                        .Build();
                case TipoValidacion.Cuarta:
                    return builder.AgregarRegla(new LongitudRegla(8))
                        .AgregarRegla(new ContieneMayusculaRegla())
                        .AgregarRegla(new ContieneNumeroRegla())
                        .AgregarRegla(new ContieneGuionBajoRegla())
                        .AgregarStrategy(new UnaPuedeFallarStrategy())
                        .Build();
                default:
                    throw new Exception("No se encontro el grupo de reglas");
            };
        }
    }
}