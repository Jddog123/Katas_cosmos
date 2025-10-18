using CalculateStats.Enum;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CalculateStats;

public class CalculateStatsTest
{
    private readonly Secuencia _secuencia = new Secuencia();

    [Fact]
    public void Si_SecuenciaEsVacia_Debe_RetornarExcepcion()
    {
        //Arrange
        int[] secuencia = [];
        //Act
        var resultado = ()=>
        {
            _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.SencuenciaVacia);
        };
        //Assert
        resultado.Should().ThrowExactly<Exception>("La secuencia se encuentra vacia");
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10,11} , 11)]
    [InlineData(new int[] {1,2,3,4,} , 4)]
    [InlineData(new int[] {5,6,80,9,1} , 5)]
    [InlineData(new int[] {6, 9, 15, -2, 92, 11} , 6)]
    public void Si_SecuenciaExiste_Debe_RetornarCantidadElementos(int[] secuencia , decimal cantidadEsperada)
    {
        //Act
        decimal resultado = _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.CantidadElementos);
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10,11} , 1)]
    [InlineData(new int[] {7,6,5,4,3,2,1} , 1)]
    [InlineData(new int[] {20,60,2,22,200} , 2)]
    [InlineData(new int[] {6, 9, 15, -2, 92, 11} , -2)]
    public void Si_SecuenciaContieneValores_Debe_RetornarValorMinimo(int[] secuencia , decimal  cantidadEsperada)
    {
        //Action
        decimal resultado = _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.Minimo); 
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10,11} , 11)]
    [InlineData(new int[] {7,6,5,4,3,2,1} , 7)]
    [InlineData(new int[] {20,60,101,22,2} , 101)]
    [InlineData(new int[] {6, 9, 15, -2, 92, 11} , 92)]
    public void Si_SecuenciaContieneValores_Debe_RetornarValorMaximo(int[] secuencia , decimal  cantidadEsperada)
    {
        //Action
        decimal resultado = _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.Maximo); 
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }

    [Theory]
    [InlineData(new int[] {70,100} , 85)]
    [InlineData(new int[] {30,100,40,30} , 50)]
    [InlineData(new int[] {30,100,40,30,100,20,20} , 48.57)]
    [InlineData(new int[] {6, 9, 15, -2, 92, 11} , 21.83)]
    public void Si_SecuenciaContieneValores_Debe_RetornarPromedio(int[] secuencia , decimal cantidadEsperada)
    {
        //Action
        decimal resultado = _secuencia.RecorrerSecuencia(secuencia,TipoValidacion.Promedio); 
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }
}