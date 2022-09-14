using System.Text.Json.Serialization;

namespace ProcessaDepositos.Domain.Clientes
{
    public class Cliente
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }

        public Cliente(string id, string nome, 
            string agencia, string conta)
        {
            Id = id;
            Nome = nome;
            Agencia = agencia;
            Conta = conta;
        }
    }
}
