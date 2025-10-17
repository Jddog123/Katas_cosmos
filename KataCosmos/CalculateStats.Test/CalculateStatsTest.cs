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
        //Asserts
        resultado.Should().Be(resultadoEsperado);
    }
    
    private int ValidarNumero(int primerNumero, int segundoNumero)
    {
        return primerNumero < segundoNumero ? primerNumero : segundoNumero;
    }
}
