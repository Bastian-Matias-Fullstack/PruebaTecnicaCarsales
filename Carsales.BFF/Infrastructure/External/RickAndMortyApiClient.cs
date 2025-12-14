using Carsales.BFF.Application.DTOs;
using Serilog;

namespace Carsales.BFF.Infrastructure.External
{
    public class RickAndMortyApiClient : IRickAndMortyApiClient
    {
        private readonly HttpClient _httpClient;
        public RickAndMortyApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<EpisodeResponseDto?> GetEpisodesAsync(int page)
        {
            try
            {
                var response = await _httpClient.GetAsync($"episode?page={page}");
                if (!response.IsSuccessStatusCode) 
                {
                    return null;
                }
                return await response.Content.ReadFromJsonAsync<EpisodeResponseDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

