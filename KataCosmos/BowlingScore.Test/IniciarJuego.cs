namespace BowlingScore.Test;

public class IniciarJuego
{
    private int puntajeRoll;
    public int ObtenerPuntaje()
    {
        return puntajeRoll;
    }
    public void RealizarRoll(int pinosDerribados)
    {
        puntajeRoll += pinosDerribados;
    }
}