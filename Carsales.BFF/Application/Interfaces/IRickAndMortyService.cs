using Carsales.BFF.Application.DTOs;

namespace Carsales.BFF.Application.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<EpisodeResponseDto?> GetEpisodesAsync(int page);
        Task<EpisodeResponseDto> SearchEpisodesAsync(string name);
    }
}
