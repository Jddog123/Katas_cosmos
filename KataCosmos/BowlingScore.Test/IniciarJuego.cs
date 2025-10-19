namespace BowlingScore.Test;

public class IniciarJuego
{
    private const int _CantidadFramesMaximo = 10;
    private const int _CantidadPinesMaximo = 10;
    private readonly List<int> puntajeRolls = new();
    public int ObtenerPuntaje()
    {
        int puntaje = 0;
        int roll = 0;

        //Se recorre los 10 frames
        for (int frame = 1; frame <= _CantidadFramesMaximo; frame++)
        {
            //En el primer roll fue strike se suma los puntos de los proximos 2 lanzamientos
            if (roll == 0 && EsStrike(roll))
            {
                puntaje += puntajeRolls[roll] + puntajeRolls[roll + 1] + puntajeRolls[roll + 2];
                //Se suma 1 posiciones en el roll actual ya, para que en strike no se realiza el 2 lanzamiento del frame
                roll += 1;
            }
            //Si es spare se suma los 10 puntos mas el puntaje del siguinere roll lanzado
            else if (EsSpare(roll))
            {
                //Se obtiene puntaje del frame primero (no se quema 10 puntos por cambian la cantidad de pinos por roll)
                int puntajeFrame = puntajeRolls[roll] + puntajeRolls[roll + 1];
                puntaje += puntajeFrame + puntajeRolls[roll + 2];
                //Se suma 2 posiciones en el roll actual ya, para que procese los siguientes roll del siguinete frame del ciclo
                roll += 2;
            }
            else
            {
                //Se suma el puntaje del 1 y 2 roll del frame
                puntaje += puntajeRolls[roll] + puntajeRolls[roll + 1];
                //Se suma 2 posiciones en el roll actual ya, para que procese los siguientes roll del siguinete frame del ciclo
                roll += 2;
            }
        }

        return puntaje;
    }
    public void RealizarRoll(int pinosDerribados)
    {
        puntajeRolls.Add(pinosDerribados);
    }
    
    private bool EsSpare(int rollIndex)
    {
        return puntajeRolls[rollIndex] + puntajeRolls[rollIndex + 1] == _CantidadPinesMaximo;
    }
    
    private bool EsStrike(int rollIndex)
    {
        return puntajeRolls[rollIndex] == _CantidadPinesMaximo;
    }
}