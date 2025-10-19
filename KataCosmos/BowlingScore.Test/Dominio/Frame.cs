namespace BowlingScore.Test.Dominio;

public class Frame
{
    private const int _maximoPinos = 10;
    private const int _maximoRolls = 2;
    private readonly List<Roll> _rolls = new();
    
    public void AgregarRoll(Roll roll)
    {
        _rolls.Add(roll);
    }
    
    public List<Roll> ObtenerRolls() => _rolls;
    public bool EsStrike => _rolls.Count > 0 && _rolls[0].Pinos == _maximoPinos;
    public bool EsSpare => _rolls.Count >= _maximoRolls && _rolls[0].Pinos + _rolls[1].Pinos == _maximoPinos;
    public bool EstaCompleto => EsStrike || _rolls.Count == _maximoRolls;
}