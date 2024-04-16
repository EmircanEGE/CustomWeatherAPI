using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Application.Services
{
    public interface IWeatherService
    {
        WeatherResponse GetWeather(string city);
    }
}