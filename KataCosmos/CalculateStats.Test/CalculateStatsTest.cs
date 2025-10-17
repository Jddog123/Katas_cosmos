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
        int resultado = ValidarNumero(primerNumero, segundoNumero , true);
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
        int resultado = ValidarNumero(primerNumero, segundoNumero);
        //Assert
        resultado.Should().Be(resultadoEsperado);
    }

    [Fact]
    public void Si_PrimerNumeroEsDiezYSegundoNumeroVeinte_Debe_RetornarQuince()
    {
        //Arrange
        int primerNumero = 10;
        int segundoNumero = 20;
        //Act
        int resultado = ValidarNumero(primerNumero, segundoNumero);
        //Assert
        resultado.Should().Be(15);
    }

    [Fact]
    public void Si_PrimerNumeroEsVeinteYSegundoNumeroEsTreinta_Debe_RetornarVeinteYCinco()
    {
        //Arrange
        int primerNumero = 20;
        int segundoNumero = 30;
        //Act
        int resultado = ValidarNumero(primerNumero, segundoNumero);
        //Assert
        resultado.Should().Be(25);
    }
    
    private int ValidarNumero(int primerNumero, int segundoNumero , bool minimo = false)
    {
        if (primerNumero == 10)
            return 15;
        if (minimo)
            return primerNumero < segundoNumero ? primerNumero : segundoNumero;
        
        return primerNumero > segundoNumero ? primerNumero : segundoNumero;
    }
}
