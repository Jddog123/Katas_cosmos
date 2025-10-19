using BowlingScore.Test.Dominio;

namespace BowlingScore.Test;

public class Juego
{
    private readonly List<Frame> _frames = new();
    
    public int ObtenerPuntaje()
    {
        int puntaje = 0;
        int roll = 0;
        var Rolls = _frames.SelectMany(f => f.ObtenerRolls()).ToList();
        
        //Se recorre los 10 frames
        foreach (Frame frame in _frames)
        {
            //En el primer roll fue strike se suma los puntos de los proximos 2 lanzamientos
            if (frame.EsStrike)
            {
                puntaje += Rolls[roll].Pinos + Rolls[roll + 1].Pinos + Rolls[roll + 2].Pinos;
                //Se suma 1 posiciones en el roll actual ya, para que en strike no se realiza el 2 lanzamiento del frame
                roll += 1;
            }
            //Si es spare se suma los 10 puntos mas el puntaje del siguinere roll lanzado
            else if (frame.EsSpare)
            {
                //Se obtiene puntaje del frame primero (no se quema 10 puntos por cambian la cantidad de pinos por roll)
                int puntajeFrame = Rolls[roll].Pinos + Rolls[roll + 1].Pinos;
                puntaje += puntajeFrame + Rolls[roll + 2].Pinos;
                //Se suma 2 posiciones en el roll actual ya, para que procese los siguientes roll del siguinete frame del ciclo
                roll += 2;
            }
            else
            {
                //Se suma el puntaje del 1 y 2 roll del frame
                puntaje += Rolls[roll].Pinos + Rolls[roll + 1].Pinos;
                //Se suma 2 posiciones en el roll actual ya, para que procese los siguientes roll del siguinete frame del ciclo
                roll += 2;
            }
        }

        return puntaje;
    }
    
    public void RealizarRoll(int pinosDerribados)
    {
        var roll = new Roll(pinosDerribados);
        Frame frameActual = _frames.LastOrDefault();
        
        if (frameActual == null || frameActual.EstaCompleto)
        {
            frameActual = new Frame();
            _frames.Add(frameActual);
        }

        frameActual.AgregarRoll(roll);
    }
}