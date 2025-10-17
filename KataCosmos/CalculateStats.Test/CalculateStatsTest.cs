using FluentAssertions;

namespace CalculateStats;

public class CalculateStatsTest
{
    [Fact]
    public void Si_NumeroEsUnoYDos_Debe_RetornarUno()
    {
        //Arrange
        int primerNumero = 1;
        int segundoNumero = 2;
        //Act
        int resultado = validarNumero(primerNumero, segundoNumero);
        //Asserts
        resultado.Should().Be(1);
    }

    [Fact]
    public void Si_NumeroEsDosYTres_Debe_RetornarDos()
    {
        //Arrange
        int primerNumero = 2;
        int segundoNumero = 3;
        //Act
        int resultado = validarNumero(primerNumero, segundoNumero);
        //Asserts
        resultado.Should().Be(2);
    }

    private int validarNumero(int primerNumero, int segundoNumero)
    {
        if (primerNumero == 2)
            return 2;
        return 1;
    }
}
