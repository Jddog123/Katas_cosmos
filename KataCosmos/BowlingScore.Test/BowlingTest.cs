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

    [Fact]
    public void Si_RealizaVeinteLanzamientosConCeroPuntajeEnCadaUno_Debe_PuntajeSerCero()
    {
        //Arrange
        int puntaje = IniciarJuego();
        //Act
        for (int i = 1; i <= 20; i++)
        {
            RealizarLanzamiento(0);
        }
        
        //Assert
        puntaje.Should().Be(0);
    }
    
    private int puntajeRoll;

    private void RealizarLanzamiento(int pinosDerribados)
    {
        puntajeRoll = pinosDerribados;
    }

    private int IniciarJuego()
    {
        return 0;
    }
}