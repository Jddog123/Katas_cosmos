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

    [Theory]
    [InlineData(new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }, 0)]
    [InlineData(new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }, 20)]
    [InlineData(new int[] { 6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6 }, 120)]
    public void Si_RealizaElMismoPuntajeEnVeinteRolls_Debe_PuntajeSerElMismoPuntajePorVeinte(int[] rolls, int puntajeEsperado)
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        foreach (var roll in rolls)
        {
            iniciarJuego.RealizarRoll(roll);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new int[] { 7,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }, 16)]
    [InlineData(new int[] { 0,0,0,0,4,6,5,0,0,0,0,0,0,0,0,0,0,0,0,0 }, 20)]
    [InlineData(new int[] { 0,0,0,0,0,0,0,0,2,8,9,0,0,0,0,0,0,0,0,0 }, 28)]
    public void Si_RealizaSpareEnCualquierRoll_Debe_PuntajeSumarElSiguienteRollComoBono(int[] rolls, int puntajeEsperado)
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        foreach (var roll in rolls)
        {
            iniciarJuego.RealizarRoll(roll);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new int[] { 10,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }, 22)]
    [InlineData(new int[] { 0,0,0,0,10,3,6,0,0,0,0,0,0,0,0,0,0,0,0,0 }, 28)]
    [InlineData(new int[] { 0,0,0,0,0,0,0,0,10,1,4,0,0,0,0,0,0,0,0,0 }, 20)]
    public void Si_RealizaStrikeIniciandoCualquierRoll_Debe_PuntajeSumarLosDosSiguienteRollComoBono(int[] rolls, int puntajeEsperado)
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        foreach (var roll in rolls)
        {
            iniciarJuego.RealizarRoll(roll);
        }
        //Assert
        iniciarJuego.ObtenerPuntaje().Should().Be(puntajeEsperado);
    }
    
    [Fact]
    public void Si_SeRealizanMasDeDiezFrames_Debe_LanzarExcepcion()
    {
        //Arrange
        var iniciarJuego = new Juego();
        
        for (int i = 1; i <= 20; i++)
        {
            iniciarJuego.RealizarRoll(1);
        }
        //Act
        var resultado = ()=> iniciarJuego.RealizarRoll(1);
        //Assert
        resultado.Should().ThrowExactly<Exception>("No se permite mas de 10 frames");
    }

    [Fact]
    public void Si_SeDerribanMasDeDiezPinosPorRoll_Debe_LanzarExcepcion()
    {
        //Arrange
        var iniciarJuego = new Juego();
        //Act
        var resultado = ()=> iniciarJuego.RealizarRoll(11);
        //Assert
        resultado.Should().ThrowExactly<Exception>("No se permite derribar mas de 10 pinos por cada roll");
    }
}