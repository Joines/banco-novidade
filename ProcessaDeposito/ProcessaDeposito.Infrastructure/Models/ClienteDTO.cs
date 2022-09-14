using System.Text.Json.Serialization;

namespace ProcessaDepositos.Infrastructure.Models
{
    public class ClienteDTO
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Agencia")]
        public string Agencia { get; set; }

        [JsonPropertyName("Conta")]
        public string Conta { get; set; }
    }
}
