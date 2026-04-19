using System;

namespace Ex02_Cofre
{
    class Program
    {
        static void Main(string[] args)
        {
            Cofre meuCofre = new Cofre("Ruan", "1234");
            
            Console.WriteLine($"Cofre do {meuCofre.Dono} está aberto? {meuCofre.EstaAberto}");
            Console.WriteLine(meuCofre.Abrir("9999"));
            Console.WriteLine(meuCofre.Abrir("8888"));
            Console.WriteLine(meuCofre.Abrir("1234"));
            
            Console.WriteLine($"E agora, está aberto? {meuCofre.EstaAberto}");
        }
    }

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
            return $"Senha Incorreta! Tentativa {_tentativasErradas}/3";
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
}