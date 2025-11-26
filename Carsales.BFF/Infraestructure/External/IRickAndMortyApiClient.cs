using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.DTOs.Carsales.BFF.Application.DTOs;

namespace Carsales.BFF.Infrastructure.External
{
    public interface IRickAndMortyApiClient
    {
        Task<EpisodeResponseDto?> GetEpisodesAsync(int page);
    }
}
