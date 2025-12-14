using System.Text.Json.Serialization;

namespace Carsales.BFF.Application.DTOs
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        [JsonPropertyName("Air_Date")]
        public string AirDate { get; set; } = "";
        public string Episode { get; set; } = "";
        public List<string> Characters { get; set; } = new();
        public string Url { get; set; } = "";
        public string Created { get; set; } = "";
    }
}
