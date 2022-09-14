using System.Text.Json.Serialization;
using System;

namespace ProcessaDepositos.Infrastructure.Models
{
    public class DepositoDTO
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("AgenciaDestino")]
        public string AgenciaDestino { get; set; }

        [JsonPropertyName("ContaDestino")]
        public string ContaDestino { get; set; }

        [JsonPropertyName("AgenciaOrigem")]
        public string AgenciaOrigem { get; set; }

        [JsonPropertyName("ContaOrigem")]
        public string ContaOrigem { get; set; }

        [JsonPropertyName("Valor")]
        public double Valor { get; set; }

        [JsonPropertyName("DataTransacao")]
        public DateTime DataTransacao { get; set; }
    }
}
