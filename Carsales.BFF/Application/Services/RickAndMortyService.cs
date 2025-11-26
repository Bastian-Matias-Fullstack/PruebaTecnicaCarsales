using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.DTOs.Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.Interfaces;
using Carsales.BFF.Application.Mappers;
using Carsales.BFF.Domain;
using Carsales.BFF.Infrastructure.External;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Carsales.BFF.Application.Services
{


    public class RickAndMortyService : IRickAndMortyService
    {
        private const string AllEpisodesCacheKey = "all_episodes_cache";

        private readonly IMemoryCache _cache;
        private readonly IRickAndMortyApiClient _apiClient;

        public RickAndMortyService(IRickAndMortyApiClient apiClient, IMemoryCache cache)
        {
            _apiClient = apiClient;
            _cache = cache;
        }

        /*obtenemos los episodios implementando cache que dura 30 segundos maximo antes de pedir directo a la api*/
        public async Task<EpisodeResponseDto?> GetEpisodesAsync(int page)
        {
            string cacheKey = $"episodes_page_{page}";

            if (_cache.TryGetValue(cacheKey, out EpisodeResponseDto cachedData))
            {
                // Log profesional
                Log.Information("Obteniendo episodios desde caché. Página: {Page}", page);
                return cachedData;
            }

            // No está en cache asi que llamamos a la API externa
            var result = await _apiClient.GetEpisodesAsync(page);

            if (result != null)
            {
                /*usamos serilog */
                Log.Information("Guardando episodios en caché. Página: {Page}", page);

                _cache.Set(
                    cacheKey,
                    result,
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                    }
                );
            }

            return result;
        }

        /*se encarga de buscar solamente*/
        public async Task<EpisodeResponseDto> SearchEpisodesAsync(string name)
        {
            var allEpisodes = await GetAllEpisodesAsync();

            // AQUÍ VA EL FILTRO NUEVO 

            var filtered = allEpisodes
                .Where(ep =>
                    ep.Title.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                    ep.Code.Contains(name, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            // AQUÍ TERMINA EL FILTRO NUEVO 

            return new EpisodeResponseDto
            {
                Info = new InfoDto
                {
                    Count = filtered.Count,
                    Pages = 1,
                    Next = null,
                    Prev = null
                },
                Results = filtered
                    .Select(EpisodeMapper.ToDto)
                    .ToList()
            };
        }


        private async Task<List<Episode>> GetAllEpisodesAsync()
        {
            // ¿Existe en caché?
            if (_cache.TryGetValue(AllEpisodesCacheKey, out List<Episode> cachedList))
            {
                Log.Information("Obteniendo TODA la lista de episodios desde caché.");
                return cachedList;
            }

            Log.Information("Cargando todas las páginas de episodios desde API externa.");

            var firstPage = await _apiClient.GetEpisodesAsync(1);
            if (firstPage == null) return new List<Episode>();

            var allEpisodes = new List<Episode>();

            // Convertir página 1
            allEpisodes.AddRange(firstPage.Results.Select(EpisodeMapper.ToDomain));

            // Obtener todas las páginas restantes
            for (int page = 2; page <= firstPage.Info.Pages; page++)
            {
                var pageData = await _apiClient.GetEpisodesAsync(page);
                if (pageData != null)
                    allEpisodes.AddRange(pageData.Results.Select(EpisodeMapper.ToDomain));
            }

            // Guardar toda la lista en caché por 60 segundos
            _cache.Set(AllEpisodesCacheKey, allEpisodes,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });

            return allEpisodes;
        }





    }



}
