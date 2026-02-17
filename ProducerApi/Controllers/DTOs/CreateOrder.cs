using System.Text.Json.Serialization;

namespace ProducerApi.Controllers.DTOs
{
    public record CreateOrderDTO
    {
        [JsonPropertyName("items")]
        public IList<string> Items { get; set; }
    }
}
