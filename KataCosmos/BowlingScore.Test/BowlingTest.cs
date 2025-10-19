using FluentAssertions;

namespace BowlingScore.Test;

public class BowlingTest
{
    [Fact]
    public void Si_IniciaJuego_Debe_PuntajeSerCero()
    {
        //Arrange
        var iniciarJuego = new IniciarJuego();
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(0);
    }

    [Fact]
    public void Si_RealizaVeinteLanzamientosConCeroPuntajeEnCadaUno_Debe_PuntajeSerCero()
    {
        //Arrange
        var iniciarJuego = new IniciarJuego();
        //Act
        for (int i = 1; i <= 20; i++)
        {
            iniciarJuego.RealizarLanzamiento(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(0);
    }
}