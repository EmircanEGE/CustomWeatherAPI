using WeatherApi.Data.Models;

namespace WeatherApi.Application.Dtos;

public class DistrictDto
{
    public string Name { get; set; }
    public CityDto? City { get; set; }

    public static DistrictDto Map(District district)
    {
        return new DistrictDto
        {
            Name = district.Name,
            City = district.City == null ? null : CityDto.Map(district.City)
        };
    }
}