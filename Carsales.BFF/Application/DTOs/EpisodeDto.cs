namespace Carsales.BFF.Application.Dtos
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Air_Date { get; set; } = "";
        public string Episode { get; set; } = "";
        public List<string> Characters { get; set; } = new();
        public string Url { get; set; } = "";
        public string Created { get; set; } = "";
    }
}
