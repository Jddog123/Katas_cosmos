using System.Numerics;
using CalculateStats.Enum;

namespace CalculateStats;

public class Secuencia
{
    public decimal RecorrerSecuencia(int[] secuencia, TipoValidacion tipoValidacion)
    {
        switch (tipoValidacion)
        {
            case TipoValidacion.CantidadElementos:
                return secuencia.Length;
            case TipoValidacion.Minimo:
                return secuencia.Min();
            case TipoValidacion.Maximo:
                return secuencia.Max();
            case TipoValidacion.Promedio:
                return Math.Round(Convert.ToDecimal(secuencia.Average()), 2);
            default: throw new Exception("La secuencia se encuentra vacia");
        }
    }
}