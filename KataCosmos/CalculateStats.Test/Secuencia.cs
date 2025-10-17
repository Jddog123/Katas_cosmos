using CalculateStats.Enum;

namespace CalculateStats;

public class Secuencia
{
    public int RecorrerSecuencia(int[] secuencia)
    {
        if (secuencia.Any())
            return secuencia.Length;
        throw new Exception("La secuencia se encuentra vacia");
    }

    public int ValidarNumero(int primerNumero, int segundoNumero , TipoValidacion tipoValidacion)
    {
        if (tipoValidacion.Equals(TipoValidacion.Minimo))
            return primerNumero < segundoNumero ? primerNumero : segundoNumero;
        if(tipoValidacion.Equals(TipoValidacion.Maximo))
            return primerNumero > segundoNumero ? primerNumero : segundoNumero;
        return (primerNumero + segundoNumero) / 2;
    }
}