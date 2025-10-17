using FluentAssertions;

namespace CalculateStats;

public class CalculateStatsTest
{
    [Theory]
    [InlineData(1, 2 , 1)]
    [InlineData(2, 3 , 2)]
    [InlineData(3, 4 , 3)]
    public void Si_PrimerNumeroEsMenorSegundoNumero_Debe_RetornarPrimerNumero(int primerNumero, int segundoNumero, int resultadoEsperado)
    {
        //Act
        int resultado = ValidarNumero(primerNumero, segundoNumero);
        //Assert
        resultado.Should().Be(resultadoEsperado);
    }

    [Fact]
    public void Si_PrimerNumeroEsCincoYSegundoNumeroEsSeis_Debe_RetornarSeis()
    {
        //Arrange
        int primerNumero = 5;
        int segundoNumero = 6;
        //Act
        int resultado = ValidarNumero(primerNumero, segundoNumero);
        //Assert
        resultado.Should().Be(6);
    }
    
    private int ValidarNumero(int primerNumero, int segundoNumero)
    {
        return primerNumero < segundoNumero ? primerNumero : segundoNumero;
    }
}
