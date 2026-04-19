using System;

namespace Ex01_Lampada
{
    class Program
    {
        static void Main(string[] args)
        {
            Lampada l = new Lampada("Philips", "LED");
            l.Alternar(); 
            l.AjustarBrilho(80);
            Console.WriteLine(l.ToString());
        }
    }

    public class Lampada
    {
        public string Marca { get; set; }
        private readonly string _tecnologia;
        private bool _ligada;
        private int _brilho;

        public Lampada(string marca, string tecnologia)
        {
            Marca = marca;
            _tecnologia = tecnologia;
            _ligada = false;
            _brilho = 100;
        }

        public void Alternar() => _ligada = !_ligada;

        public void AjustarBrilho(int novoBrilho)
        {
            if (_ligada && novoBrilho >= 0 && novoBrilho <= 100) _brilho = novoBrilho;
        }

        public override string ToString() => $"Lâmpada {Marca} ({_tecnologia}) - Brilho: {_brilho}% - Ligada: {_ligada}";
    }
}