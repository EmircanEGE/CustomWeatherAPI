using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Infastructer.WeatherApi;

public interface IWeatherApiClient
{
    Task<WeatherResponse> GetWeather(string location);
}