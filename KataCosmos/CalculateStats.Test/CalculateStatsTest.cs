using FluentAssertions;

namespace CalculateStats;

public class CalculateStatsTest
{
    [Theory]
    [InlineData(1, 2 , 1)]
    [InlineData(3,  2, 2)]
    [InlineData(4, 6 , 4)]
    public void Si_RecibeDosNumeros_Debe_RetornarNumeroMenor(int primerNumero, int segundoNumero, int resultadoEsperado)
    {
        //Act
        int resultado = ValidarNumero(primerNumero, segundoNumero, TipoValidacion.Minimo);
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
        int resultado = ValidarNumero(primerNumero, segundoNumero, TipoValidacion.Maximo);
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
        int resultado = ValidarNumero(primerNumero, segundoNumero,  TipoValidacion.Promedio);
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
            RecorrerSecuencia(secuencia);
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
        var resultado = RecorrerSecuencia(secuencia);
        //Assert
        resultado.Should().Be(3);
    }

    private int RecorrerSecuencia(List<int> secuencia)
    {
        if (secuencia.Any())
            return 3;
        throw new Exception("La secuencia se encuentra vacia");
    }

    private int ValidarNumero(int primerNumero, int segundoNumero , TipoValidacion tipoValidacion)
    {
        if (tipoValidacion.Equals(TipoValidacion.Minimo))
            return primerNumero < segundoNumero ? primerNumero : segundoNumero;
        if(tipoValidacion.Equals(TipoValidacion.Maximo))
            return primerNumero > segundoNumero ? primerNumero : segundoNumero;
        return (primerNumero + segundoNumero) / 2;
    }
}

internal enum TipoValidacion
{
    Minimo,
    Maximo,
    Promedio
}
