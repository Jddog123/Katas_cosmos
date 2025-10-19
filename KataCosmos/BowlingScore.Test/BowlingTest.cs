using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

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
    public void Si_RealizaVeinteRollsConCeroPuntajeEnCadaUno_Debe_PuntajeSerCero()
    {
        //Arrange
        var iniciarJuego = new IniciarJuego();
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
        var iniciarJuego = new IniciarJuego();
        //Act
        for (int i = 1; i <= 20; i++)
        {
            iniciarJuego.RealizarRoll(1);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(20);
    }

    [Fact]
    public void Si_PrimerYSegundoRollsRealizaSpareYTercerRollConTresDePuntajeYDemasRollsEnCero_Debe_PuntajeSerDieciseis()
    {
        //Arrange
        var iniciarJuego = new IniciarJuego();
        //Act
        iniciarJuego.RealizarRoll(7);
        iniciarJuego.RealizarRoll(3);
        iniciarJuego.RealizarRoll(3);
        
        for (int i = 1; i <= 17; i++)
        {
            iniciarJuego.RealizarRoll(0);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(16);
    }

    [Fact]
    public void Si_QuintoYSextoRollsRealizaSpareYSeptimoConCincoDePuntajeYDemasRollsEnCero_Debe_PuntajeSerVeinte()
    {
        //Arrange
        var iniciarJuego = new IniciarJuego();
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
}