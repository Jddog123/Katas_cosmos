using CalculateStats.Enum;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace CalculateStats;

public class CalculateStatsTest
{
    private readonly Secuencia _secuencia = new Secuencia();

    [Theory]
    [InlineData(1, 2 , 1)]
    [InlineData(3,  2, 2)]
    [InlineData(4, 6 , 4)]
    public void Si_RecibeDosNumeros_Debe_RetornarNumeroMenor(int primerNumero, int segundoNumero, int resultadoEsperado)
    {
        //Act
        int resultado = _secuencia.ValidarNumero(primerNumero, segundoNumero, TipoValidacion.Minimo);
        //Assert
        resultado.Should().Be(resultadoEsperado);
    }

    [Theory]
    [InlineData(6, 7 , 7)]
    [InlineData(7, 6 , 7)]
    [InlineData(8, 11 , 11)]
    public void Si_RecibeDosNumeros_Debe_RetornarNumeroMayor(int primerNumero, int segundoNumero, int resultadoEsperado)
    {
        //Act
        int resultado = _secuencia.ValidarNumero(primerNumero, segundoNumero, TipoValidacion.Maximo);
        //Assert
        resultado.Should().Be(resultadoEsperado);
    }

    [Theory]
    [InlineData(10, 20 , 15)]
    [InlineData(20, 30 , 25)]
    [InlineData(40, 30 , 35)]
    public void Si_Recibe_DosNumeros_Debe_RetornarPromedio(int primerNumero, int segundoNumero, int resultadoEsperado)
    {
        //Act
        int resultado = _secuencia.ValidarNumero(primerNumero, segundoNumero,  TipoValidacion.Promedio);
        //Assert
        resultado.Should().Be(resultadoEsperado);
    }

    [Fact]
    public void Si_SecuenciaEsVacia_Debe_RetornarExcepcion()
    {
        //Arrange
        int[] secuencia = [];
        //Act
        var resultado = ()=>
        {
            _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.CantidadElementos);
        };
        //Assert
        resultado.Should().ThrowExactly<Exception>("La secuencia se encuentra vacia");
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10,11} , 11)]
    [InlineData(new int[] {1,2,3,4,} , 4)]
    [InlineData(new int[] {5,6,80,9,1} , 5)]
    public void Si_SecuenciaExiste_Debe_RetornarCantidadElementos(int[] secuencia , int cantidadEsperada)
    {
        //Act
        var resultado = _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.CantidadElementos);
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10,11} , 1)]
    [InlineData(new int[] {7,6,5,4,3,2,1} , 1)]
    [InlineData(new int[] {20,60,2,22,200} , 2)]
    public void Si_SecuenciaContieneValores_Debe_RetornarValorMinimo(int[] secuencia , int  cantidadEsperada)
    {
        //Action
        var resultado = _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.Minimo); 
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }

    [Theory]
    [InlineData(new int[] {1,2,3,4,5,6,7,8,9,10,11} , 11)]
    [InlineData(new int[] {7,6,5,4,3,2,1} , 7)]
    [InlineData(new int[] {20,60,101,22,2} , 101)]
    public void Si_SecuenciaContieneValores_Debe_RetornarValorMaximo(int[] secuencia , int  cantidadEsperada)
    {
        //Action
        var resultado = _secuencia.RecorrerSecuencia(secuencia, TipoValidacion.Maximo); 
        //Assert
        resultado.Should().Be(cantidadEsperada);
    }
}