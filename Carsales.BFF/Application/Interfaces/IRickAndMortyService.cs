using Carsales.BFF.Application.Dtos;
using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.DTOs.Carsales.BFF.Application.DTOs;
using Carsales.BFF.Domain;

namespace Carsales.BFF.Application.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<EpisodeResponseDto?> GetEpisodesAsync(int page);

        Task<EpisodeResponseDto> SearchEpisodesAsync(string name);

    }
}
