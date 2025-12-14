using System.Text.Json.Serialization;

namespace Carsales.BFF.Domain
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("Air_Date")]
        public DateTime AirDate { get; set; }
        public string Code { get; set; } = string.Empty;
        public List<string> Characters { get; set; } = new();
    }
}
