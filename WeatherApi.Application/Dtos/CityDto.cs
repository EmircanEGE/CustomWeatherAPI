using WeatherApi.Data.Models;

namespace WeatherApi.Application.Dtos;

public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PlaqueCode { get; set; }
    public string LowerName { get; set; }

    public static CityDto Map(City city)
    {
        return new CityDto
        {
            Id = city.Id,
            Name = city.Name,
            PlaqueCode = city.Id.ToString(),
            LowerName = city.Name.ToLower()
        };
    }
}