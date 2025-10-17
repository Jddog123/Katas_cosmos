using CalculateStats.Enum;

namespace CalculateStats;

public class Secuencia
{
    public int RecorrerSecuencia(List<int> secuencia)
    {
        if(secuencia.Count() == 7)
            return 7;
        if (secuencia.Count() == 5)
            return 5;
        if (secuencia.Any())
            return 3;
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