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

    private int validarNumero(int primerNumero, int segundoNumero)
    {
        throw new NotImplementedException();
    }
}
