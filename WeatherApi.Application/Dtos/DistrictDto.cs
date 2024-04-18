using WeatherApi.Data.Models;

namespace WeatherApi.Application.Dtos;

public class DistrictDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CityDto? City { get; set; }

    public static DistrictDto Map(District district)
    {
        return new DistrictDto
        {
            Id = district.Id,
            Name = district.Name,
            City = district.City == null ? null : CityDto.Map(district.City)
        };
    }
}