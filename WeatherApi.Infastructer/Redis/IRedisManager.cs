using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Infastructer.Redis
{
    public interface IRedisManager
    {
        WeatherResponse GetWeather(string location);
        void SetWeather(string location, WeatherResponse weather);
    }
}