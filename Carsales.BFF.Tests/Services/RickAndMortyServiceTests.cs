using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.Services;
using Carsales.BFF.Infrastructure.External;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;

public class RickAndMortyServiceTests
{
    // Método helper para crear un IMemoryCache funcional
    private Mock<IMemoryCache> CreateMemoryCacheMock()
    {
        var mockCache = new Mock<IMemoryCache>();

        // Mock de ICacheEntry (necesario para evitar NullReferenceException)
        var mockEntry = new Mock<ICacheEntry>();
        mockEntry.SetupAllProperties();

        mockCache
            .Setup(m => m.CreateEntry(It.IsAny<object>()))
            .Returns(mockEntry.Object);
        return mockCache;
    }

    //SearchEpisodesAsync devuelva episodios correctamente cuando la API devuelve datos
    [Fact]
    public async Task GetEpisodesAsync_ShouldReturnEpisodes_WhenApiReturnsData()
    {
        // Arrange
        var mockApiClient = new Mock<IRickAndMortyApiClient>();
        var mockCache = CreateMemoryCacheMock();
        var fakeResponse = new EpisodeResponseDto
        {
            Info = new InfoDto { Count = 1, Pages = 1 },
            Results = new List<EpisodeDto>
            {
              new EpisodeDto { Id = 1, Name = "Pilot" }
            }

        };

        mockApiClient
            .Setup(c => c.GetEpisodesAsync(1))
            .ReturnsAsync(fakeResponse);

        var service = new RickAndMortyService(mockApiClient.Object, mockCache.Object);

        // Act
        var result = await service.GetEpisodesAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Results.Should().HaveCount(1);
    }

    //SearchEpisodesAsync devuelva episodios correctamente cuando la API devuelve datos.
    [Fact]
    public async Task SearchEpisodesAsync_ShouldReturnEpisodes_WhenApiReturnsData()
    {
        // Arrange
        var mockApiClient = new Mock<IRickAndMortyApiClient>();
        var mockCache = CreateMemoryCacheMock();
        var fakeResponse = new EpisodeResponseDto
        {
            Info = new InfoDto { Count = 1, Pages = 1 },
            Results = new List<EpisodeDto>
        {
            new EpisodeDto { Id = 1, Name = "Pilot" },
        }
        };

        mockApiClient
            .Setup(c => c.GetEpisodesAsync(1))
            .ReturnsAsync(fakeResponse);

        var service = new RickAndMortyService(mockApiClient.Object, mockCache.Object);

        // Act
        var result = await service.SearchEpisodesAsync("Pilot");

        // Assert
        result.Should().NotBeNull();
        result.Results.Should().HaveCount(1);
    }

    //validar que NO se llame al ApiClient si el dato ya está en memoria.
    [Fact]
    public async Task GetEpisodesAsync_ShouldUseCache_WhenDataIsCached()
    {
        // Arrange
        var mockApiClient = new Mock<IRickAndMortyApiClient>();
        var mockCache = new Mock<IMemoryCache>();

        var cachedData = new EpisodeResponseDto
        {
            Info = new InfoDto(),
            Results = new List<EpisodeDto>()
        };

        object outObj = cachedData;

        // Configurar TryGetValue TRUE para simular cache hit
        mockCache
            .Setup(c => c.TryGetValue(It.IsAny<object>(), out outObj))
            .Returns(true);

        var service = new RickAndMortyService(mockApiClient.Object, mockCache.Object);

        // Act
        var result = await service.GetEpisodesAsync(1);

        // Assert
        result.Should().BeSameAs(cachedData);
        mockApiClient.Verify(c => c.GetEpisodesAsync(It.IsAny<int>()), Times.Never);
    }
}



