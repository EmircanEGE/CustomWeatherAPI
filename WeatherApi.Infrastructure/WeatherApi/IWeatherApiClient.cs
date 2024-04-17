using WeatherApi.Infrastructure.WeatherApi.Models;

namespace WeatherApi.Infrastructure.WeatherApi;

public interface IWeatherApiClient
{
    Task<WeatherResponse> GetWeather(string location);
}