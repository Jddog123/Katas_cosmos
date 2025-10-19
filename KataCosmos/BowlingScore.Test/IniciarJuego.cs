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
            //Si es el segundo frame se aplica logicasi en el primer frame hubo spare
            if (frame == 2 && puntaje == 10)
            {
                puntaje += (puntajeRolls[roll]*2);
                break;
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
}