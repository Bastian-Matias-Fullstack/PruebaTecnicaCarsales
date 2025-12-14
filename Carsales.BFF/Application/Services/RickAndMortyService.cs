using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.Interfaces;
using Carsales.BFF.Application.Mappers;
using Carsales.BFF.Domain;
using Carsales.BFF.Infrastructure.External;
using Microsoft.Extensions.Caching.Memory;

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
        public async Task<EpisodeResponseDto?> GetEpisodesAsync(int page)
        {
            string cacheKey = $"episodes_page_{page}";

            if (_cache.TryGetValue(cacheKey, out EpisodeResponseDto cachedData))
            {
                return cachedData;
            }
            var result = await _apiClient.GetEpisodesAsync(page);
            if (result != null)
            {
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
        public async Task<EpisodeResponseDto> SearchEpisodesAsync(string name)
        {
            var allEpisodes = await GetAllEpisodesAsync();
            var filtered = allEpisodes
                .Where(ep =>
                    ep.Title.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                    ep.Code.Contains(name, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();
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
            if (_cache.TryGetValue(AllEpisodesCacheKey, out List<Episode> cachedList))
            {
                return cachedList;
            }
            var firstPage = await _apiClient.GetEpisodesAsync(1);
            if (firstPage == null) return new List<Episode>();
            var allEpisodes = new List<Episode>();
            allEpisodes.AddRange(firstPage.Results.Select(EpisodeMapper.ToDomain));
            for (int page = 2; page <= firstPage.Info.Pages; page++)
            {
                var pageData = await _apiClient.GetEpisodesAsync(page);
                if (pageData != null)
                    allEpisodes.AddRange(pageData.Results.Select(EpisodeMapper.ToDomain));
            }
            _cache.Set(AllEpisodesCacheKey, allEpisodes,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            return allEpisodes;
        }
    }
}