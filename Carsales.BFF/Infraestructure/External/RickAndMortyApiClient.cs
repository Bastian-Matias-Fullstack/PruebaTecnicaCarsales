using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.DTOs.Carsales.BFF.Application.DTOs;
using Carsales.BFF.Infraestructure.External;
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
                Log.Information("Solicitando episodios. Página: {Page}", page);

                var response = await _httpClient.GetAsync($"episode?page={page}");

                if (!response.IsSuccessStatusCode) 
                {
                    Log.Warning("La API devolvió un código no exitoso: {StatusCode}", response.StatusCode);
                    return null;

                }
                Log.Information("Episodios obtenidos correctamente desde Rick and Morty API. Página: {Page}", page);

                return await response.Content.ReadFromJsonAsync<EpisodeResponseDto>();
            }
            catch (Exception ex)
            {
                // en un caso real se haría registro con logging
                Log.Error(ex, "Error al consumir la API de Rick and Morty.");
                return null;
            }
        }
    }
}

