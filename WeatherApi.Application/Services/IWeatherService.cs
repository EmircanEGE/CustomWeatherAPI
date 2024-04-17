using WeatherApi.Infrastructure.WeatherApi.Models;

namespace WeatherApi.Application.Services;

public interface IWeatherService
{
    Task<WeatherResponse> GetWeather(string city);
}