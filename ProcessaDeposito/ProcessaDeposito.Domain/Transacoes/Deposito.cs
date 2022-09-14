using System;
using System.Text.Json.Serialization;

namespace ProcessaDepositos.Domain.Transacoes
{    
    public class Deposito
    {        
        public string Id { get; set; }
        
        public string Nome { get; set; }
        
        public string AgenciaDestino { get; set; }
        
        public string ContaDestino { get; set; }
        
        public string AgenciaOrigem { get; set; }
        
        public string ContaOrigem { get; set; }
        
        public double Valor { get; set; }
        
        public DateTime DataTransacao { get; set; }

        public Deposito(string id, string nome, string agenciaDestino, string contaDestino, 
            string agenciaOrigem, string contaOrigem, double valor, DateTime dataTransacao)
        {
            Id = id;
            Nome = nome;
            AgenciaDestino = agenciaDestino;
            ContaDestino = contaDestino;
            AgenciaOrigem = agenciaOrigem;
            ContaOrigem = contaOrigem;
            Valor = valor;
            DataTransacao = dataTransacao;
        }
    }
}
