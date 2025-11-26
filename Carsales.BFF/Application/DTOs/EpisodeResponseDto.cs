using Carsales.BFF.Application.Dtos;

namespace Carsales.BFF.Application.DTOs
{
    namespace Carsales.BFF.Application.DTOs
    {
        public class EpisodeResponseDto
        {
            public InfoDto Info { get; set; } = new();
            public List<EpisodeDto> Results { get; set; } = new();
        }



      
    }

}
