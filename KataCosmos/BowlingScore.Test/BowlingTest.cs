using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace BowlingScore.Test;

public class BowlingTest
{
    [Fact]
    public void Si_IniciaJuego_Debe_PuntajeSerCero()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(0);
    }

    [Fact]
    public void Si_RealizaVeinteRollsConCeroPuntajeEnCadaUno_Debe_PuntajeSerCero()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        for (int i = 1; i <= 20; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(0);
    }

    [Fact]
    public void Si_RealizaVeinteRollsConUnPuntajeEnCadaUno_Debe_PuntajeSerVeinte()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        for (int i = 1; i <= 20; i++)
        {
            iniciarJuego.RealizarRoll(1);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(20);
    }

    [Fact]
    public void Si_PrimerYSegundoRollsRealizaSpareYTercerRollConTresDePuntajeYDiecisieteRollsEnCero_Debe_PuntajeSerDieciseis()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        //INICIO SPARE
        iniciarJuego.RealizarRoll(7);
        iniciarJuego.RealizarRoll(3);
        //FIN SPARE
        iniciarJuego.RealizarRoll(3);
        
        for (int i = 1; i <= 17; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(16);
    }

    [Fact]
    public void Si_QuintoYSextoRollsRealizaSpareYSeptimoConCincoDePuntajeYDiecisieteRollsEnCero_Debe_PuntajeSerVeinte()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        for (int i = 1; i <= 4; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        
        //INICIO SPARE
        iniciarJuego.RealizarRoll(4);
        iniciarJuego.RealizarRoll(6);
        //FIN SPARE
        iniciarJuego.RealizarRoll(5);
        
        for (int i = 1; i <= 13; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(20);
    }

    [Fact]
    public void Si_EnPrimerRollRealizaStrikeYSegundoYTercerRollTresPuntosYDieciseisRollsEnCeroPuntos_Debe_PuntajeSerVeinteYDos()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        //INICIO STRIKE
        iniciarJuego.RealizarRoll(10);
        //FIN STRIKE
        iniciarJuego.RealizarRoll(3);
        iniciarJuego.RealizarRoll(3);
        
        for (int i = 1; i <= 16; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(22);
    }

    [Fact]
    public void Si_EnQuintoRollRealizaStrikeYSextoRollTresPuntosYSeptimoRollSeisPuntosYDieciseisRollsEnCeroPuntos_Debe_PuntajeSerVeintiocho()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        for (int i = 1; i <= 4; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        
        //INICIO STRIKE
        iniciarJuego.RealizarRoll(10);
        //FIN STRIKE
        iniciarJuego.RealizarRoll(3);
        iniciarJuego.RealizarRoll(6);
        
        for (int i = 1; i <= 12; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(28);
    }
}