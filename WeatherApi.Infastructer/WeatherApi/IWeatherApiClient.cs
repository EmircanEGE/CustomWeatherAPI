using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Infastructer.WeatherApi;

public interface IWeatherApiClient
{
    WeatherResponse GetWeather(string location);
}