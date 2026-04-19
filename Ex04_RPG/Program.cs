using System;

namespace Ex04_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Personagem p1 = new Personagem("player, o Guerreiro", "Guerreiro");
            Personagem p2 = new Personagem("Inimigo", "Ogro");

            Console.WriteLine("--- INÍCIO DA BATALHA ---");
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

            Console.WriteLine("\n[Ataque!] player ataca o Inimigo...");
            p2.ReceberDano(40);

            Console.WriteLine("[Cura] Inimigo tenta se curar...");
            p2.Curar(10);

            Console.WriteLine("\n--- STATUS FINAL ---");
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
        }
    }

    public class Personagem
    {
        public string Nome { get; set; }
        public string Classe { get; set; }
        private int _vida;
        private int _nivel;

        public Personagem(string nome, string classe)
        {
            Nome = nome;
            Classe = classe;
            _vida = 100;
            _nivel = 1;
        }

        public void ReceberDano(int dano)
        {
            _vida -= dano;
            if (_vida < 0) _vida = 0;
            Console.WriteLine($"{Nome} recebeu {dano} de dano! Vida atual: {_vida}");
        }

        public void Curar(int quantidade)
        {
            if (_vida > 0)
            {
                _vida += quantidade;
                if (_vida > 100) _vida = 100;
                Console.WriteLine($"{Nome} se curou em {quantidade}. Vida atual: {_vida}");
            }
            else
            {
                Console.WriteLine($"{Nome} está morto e não pode ser curado!");
            }
        }

        public override string ToString()
        {
            string status = _vida > 0 ? "Vivo" : "Morto";
            return $"[{Nome}] Classe: {Classe} | Nível: {_nivel} | HP: {_vida} | Status: {status}";
        }
    }
}