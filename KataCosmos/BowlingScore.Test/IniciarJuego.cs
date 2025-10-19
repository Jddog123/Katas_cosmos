namespace BowlingScore.Test;

public class IniciarJuego
{
    private readonly List<int> puntajeRolls = new();
    public int ObtenerPuntaje()
    {
        int puntaje = 0;
        int roll = 0;

        //Se recorre los 10 frames
        for (int frame = 1; frame <= 10; frame++)
        {
            //Se obtiene puntaje del frame
            int puntajeFrame = puntajeRolls[roll] + puntajeRolls[roll + 1];
            //Si es spare se suma los 10 puntos mas el puntaje del siguinere roll lanzado
            if (EsSpare(roll))
            {
                puntaje += puntajeFrame + puntajeRolls[roll + 2];
            }
            else
            {
                //Se suma el puntaje del 1 y 2 roll del frame
                puntaje += puntajeRolls[roll] + puntajeRolls[roll + 1];
            }
            
            //Se suma 2 posiciones en el roll actual ya, para que procese los siguientes roll del siguinete frame del ciclo
            roll += 2;
        }

        return puntaje;
    }
    public void RealizarRoll(int pinosDerribados)
    {
        puntajeRolls.Add(pinosDerribados);
    }
    
    private bool EsSpare(int rollIndex)
    {
        return puntajeRolls[rollIndex] + puntajeRolls[rollIndex + 1] == 10;
    }
}