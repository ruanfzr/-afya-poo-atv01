using System;

namespace Ex03_Conta
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente minhaConta = new ContaCorrente("12345-X", "usuario");

            minhaConta.Depositar(1000);
            
            bool saqueSucesso = minhaConta.Sacar(1200);

            Console.WriteLine(minhaConta.ToString());
            Console.WriteLine($"Status: {minhaConta.StatusConta}");
            Console.WriteLine($"Saque de R$1200 realizado? {(saqueSucesso ? "Sim" : "Não")}");
        }
    }

    public class ContaCorrente
    {
        private readonly string _numeroConta;
        public string Titular { get; set; }
        private double _saldo;
        private double _limite;

        // Campos Calculados
        public double SaldoTotal => _saldo + _limite;
        public string StatusConta => _saldo < 0 ? "Negativo" : "Positivo";

        public ContaCorrente(string numero, string titular)
        {
            _numeroConta = numero;
            Titular = titular;
            _saldo = 0;
            _limite = 500;
        }

        public void Depositar(double valor)
        {
            if (valor > 0) _saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor > 0 && valor <= SaldoTotal)
            {
                _saldo -= valor;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Conta: {_numeroConta} | Titular: {Titular} | Saldo: {_saldo:C} | Limite: {_limite:C}";
        }
    }
}