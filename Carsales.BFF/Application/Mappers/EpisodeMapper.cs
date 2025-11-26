using Carsales.BFF.Domain;
using Carsales.BFF.Application.DTOs;
using Carsales.BFF.Application.Dtos;

namespace Carsales.BFF.Application.Mappers
{
    public static class EpisodeMapper
    {
        public static Episode ToDomain(EpisodeDto dto)
        {
            return new Episode
            {
                Id = dto.Id,
                Title = dto.Name,                   // transformación del campo
                AirDate = DateTime.TryParse(dto.Air_Date, out var parsedDate)
                ? parsedDate
              : DateTime.MinValue,
                Code = dto.Episode,
                Characters = dto.Characters.ToList()
            };
        }
        public static EpisodeDto ToDto(Episode domain)
        {
            return new EpisodeDto
            {
                Id = domain.Id,
                Name = domain.Title,
                Air_Date = domain.AirDate.ToString("yyyy-MM-dd"),
                Episode = domain.Code,
                Characters = domain.Characters ?? new List<string>(),
                Url = "",
                Created = ""
            };
        }

    }
}
