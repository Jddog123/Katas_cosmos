using FluentAssertions;

namespace BowlingScore.Test;

public class BowlingTest
{
    [Fact]
    public void Si_IniciaJuego_Debe_PuntajeSerCero()
    {
        //Act
        int puntaje = IniciarJuego();
        //Assert
        puntaje.Should().Be(0);
    }

    private int IniciarJuego()
    {
        return 0;
    }
}