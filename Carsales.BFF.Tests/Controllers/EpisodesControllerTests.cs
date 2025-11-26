using Carsales.BFF.Application.Dtos;
using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.DTOs.Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.Interfaces;
using Carsales.BFF.Controllers;
using Carsales.BFF.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsales.BFF.Tests.Controllers
{
    public class EpisodesControllerTests
    {
        /*Retorna 200 OK cuando hay datos*/
        [Fact]
        public async Task GetEpisodes_ShouldReturnOk_WhenServiceReturnsData()
        {
            // Arrange
            var mockService = new Mock<IRickAndMortyService>();

            mockService.Setup(s => s.GetEpisodesAsync(1))
                .ReturnsAsync(new EpisodeResponseDto
                {
                    Info = new InfoDto { Count = 1, Pages = 1 },
                    Results = new List<EpisodeDto>
                    {
                new EpisodeDto { Id = 1, Name = "Pilot" }
                    }
                });

            var controller = new EpisodesController(mockService.Object);

            // Act
            var result = await controller.GetEpisodes(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        /*Retorna 400 BadRequest si page < 1*/
        [Fact]
        public async Task GetEpisodes_ShouldReturnBadRequest_WhenPageIsLessThanOne()
        {
            // Arrange
            var mockService = new Mock<IRickAndMortyService>();
            var controller = new EpisodesController(mockService.Object);

            // Act
            var result = await controller.GetEpisodes(0);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }


        /*Retorna 502 cuando el servicio devuelve null*/
        [Fact]
        public async Task GetEpisodes_ShouldReturn502_WhenServiceReturnsNull()
        {
            // Arrange
            var mockService = new Mock<IRickAndMortyService>();

            mockService.Setup(s => s.GetEpisodesAsync(1))
                .ReturnsAsync((EpisodeResponseDto?)null);

            var controller = new EpisodesController(mockService.Object);

            // Act
            var result = await controller.GetEpisodes(1);

            // Assert
            result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(502);
        }

        /*BadRequest si name está vacío*/
        [Fact]
        public async Task SearchEpisodes_ShouldReturnBadRequest_WhenNameIsEmpty()
        {
            var mockService = new Mock<IRickAndMortyService>();
            var controller = new EpisodesController(mockService.Object);

            var result = await controller.SearchEpisodes("");

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        /*Retorna 200 OK cuando el servicio devuelve datos*/
        [Fact]
        public async Task SearchEpisodes_ShouldReturnOk_WhenServiceReturnsData()
        {
            var mockService = new Mock<IRickAndMortyService>();

            mockService.Setup(s => s.SearchEpisodesAsync("Pilot"))
                .ReturnsAsync(new EpisodeResponseDto
                {
                    Info = new InfoDto { Count = 1, Pages = 1 },
                    Results = new List<EpisodeDto>
                    {
                        new EpisodeDto { Id = 1, Name = "Pilot", Episode = "S01E01" }
                    }
                });

            var controller = new EpisodesController(mockService.Object);

            var result = await controller.SearchEpisodes("Pilot");

            result.Should().BeOfType<OkObjectResult>();
        }
    }
}

