using System.Numerics;
using CalculateStats.Enum;

namespace CalculateStats;

public class Secuencia
{
    public int RecorrerSecuencia(int[] secuencia, TipoValidacion tipoValidacion)
    {
        if (tipoValidacion == TipoValidacion.Minimo)
        {
            int minimo = secuencia[0];
            for (int i = 1; i < secuencia.Length; i++)
            {
                minimo = ValidarNumero(minimo, secuencia[i], TipoValidacion.Minimo);
            }
            return minimo;
        }
        
        if (tipoValidacion == TipoValidacion.Maximo)
        {
            int maximo = secuencia[0];
            for (int i = 1; i < secuencia.Length; i++)
            {
                maximo = ValidarNumero(maximo, secuencia[i], TipoValidacion.Maximo);
            }
            return maximo;
        }
        
        return secuencia.Any() ? secuencia.Length : throw new Exception("La secuencia se encuentra vacia");
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