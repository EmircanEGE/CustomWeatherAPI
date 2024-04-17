using WeatherApi.Data.Models;

namespace WeatherApi.Application.Dtos;

public class CityDto
{
    public string Name { get; set; }

    public static CityDto Map(City city)
    {
        return new CityDto
        {
            Name = city.Name
        };
    }
}