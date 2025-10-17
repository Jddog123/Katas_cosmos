using CalculateStats.Enum;
using FluentAssertions;

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
        List<int> secuencia= new List<int>();
        //Act
        var resultado = ()=>
        {
            _secuencia.RecorrerSecuencia(secuencia);
        };
        //Assert
        resultado.Should().ThrowExactly<Exception>("La secuencia se encuentra vacia");
    }

    [Fact]
    public void Si_SecenciaContieneUnoDosYDiez_Debe_RetornarTres()
    {
        //Arrange
        List<int> secuencia = new List<int>() { 1,2,10};
        //Act
        var resultado = _secuencia.RecorrerSecuencia(secuencia);
        //Assert
        resultado.Should().Be(3);
    }
    
    [Fact]
    public void Si_SecenciaContieneUnoDosTresCuatroYDiez_Debe_RetornarCinco()
    {
        //Arrange
        List<int> secuencia = new List<int>() { 1,2,3,4,10};
        //Act
        var resultado = _secuencia.RecorrerSecuencia(secuencia);
        //Assert
        resultado.Should().Be(5);
    }
}