public class Personagem
{
    public string Nome { get; set; }
    public string Classe { get; private set; }
    private int _nivel;
    private double _vidaActual;
    private double _vidaMaxima;

    public Personagem(string nome, string classe)
    {
        Nome = nome;
        Classe = (classe == "Guerreiro" || classe == "Mago") ? classe : "Guerreiro";
        _vidaMaxima = Classe == "Guerreiro" ? 150 : 80;
        _nivel = 1;
        _vidaActual = _vidaMaxima;
    }

    public void ReceberDano(double pontos)
    {
        _vidaActual -= pontos;
        if (_vidaActual < 0) _vidaActual = 0;
    }

    public void Curar(double pontos)
    {
        if (_vidaActual > 0)
        {
            _vidaActual = Math.Min(_vidaActual + pontos, _vidaMaxima);
        }
    }

    public void SubirNivel()
    {
        if (_vidaActual > 0)
        {
            _nivel++;
            _vidaMaxima *= 1.10;
            _vidaActual = _vidaMaxima;
        }
    }

    public override string ToString()
    {
        return $"{Nome} ({Classe}) - Lvl {_nivel} - HP: {Math.Round(_vidaActual)}/{Math.Round(_vidaMaxima)}";
    }
}