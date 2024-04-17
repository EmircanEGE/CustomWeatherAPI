namespace WeatherApi.Infrastructure.WeatherApi.Models;

public class LocationWeather
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public decimal Lat { get; set; }
    public decimal Lon { get; set; }
}