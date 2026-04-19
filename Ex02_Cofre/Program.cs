public class Cofre
{
    public string Dono { get; set; }
    private string _senha;
    private bool _estaAberto;
    private int _tentativasErradas;

    public bool EstaAberto => _estaAberto;

    public Cofre(string dono, string senhaInicial)
    {
        Dono = dono;
        _senha = senhaInicial;
        _estaAberto = false;
        _tentativasErradas = 0;
    }
    public string Abrir(string senhaInformada)
    {
        if (_tentativasErradas >= 3) return "Cofre Bloqueado";

        if (senhaInformada == _senha)
        {
            _estaAberto = true;
            _tentativasErradas = 0;
            return "Cofre Aberto!";
        }
        
        _tentativasErradas++;
        return "Senha Incorreta!";
    }
    public void Fechar() => _estaAberto = false;
    public void AlterarSenha(string senhaAntiga, string novaSenha)
    {
        if (_estaAberto && senhaAntiga == _senha)
        {
            _senha = novaSenha;
        }
    }
}