using System;

namespace bank
{
    public class Conta
    {
        // Propriedade pública, com get; e set; para poder ser alterada
        private TipoConta TipoConta { get; set; } 
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        // Método construtor, que é chamado quando criado meu objeto, tem o nome da classe, sempre
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            // This serve para falar que é para alterar ESSA instância, não de todas as instâncias
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
        
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            // Vai sacer o valor de uma conta e depositar (transferir) para outra conta
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }
    }
}