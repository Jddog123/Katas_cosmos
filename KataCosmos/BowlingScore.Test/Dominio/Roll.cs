namespace BowlingScore.Test.Dominio;

public class Roll
{
    public int Pinos { get; }
    public const int MaximoPinos = 10;

    public Roll(int pinos)
    {
        if (pinos > MaximoPinos)
            throw new Exception("No se permite derribar mas de 10 pinos por cada roll");
            
        Pinos = pinos;
    }
}