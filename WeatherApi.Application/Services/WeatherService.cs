using WeatherApi.Infastructer.Redis;
using WeatherApi.Infastructer.WeatherApi;
using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherApiClient _weatherApiClient;
        private readonly IRedisManager _redisManager;

        public WeatherService(IWeatherApiClient weatherApiClient, IRedisManager redisManager)
        {
            _weatherApiClient = weatherApiClient;
            _redisManager = redisManager;
        }

        public WeatherResponse GetWeather(string city)
        {
            WeatherResponse cachedResponse = _redisManager.GetWeather(city);
            if (cachedResponse != null)
                return cachedResponse;
            WeatherResponse apiResponse = _weatherApiClient.GetWeather(city);
            _redisManager.SetWeather(city, apiResponse);
            return apiResponse;
        }
    }
}