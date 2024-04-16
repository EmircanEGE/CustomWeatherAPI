using WeatherApi.Infastructer.Redis;
using WeatherApi.Infastructer.WeatherApi;
using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IRedisManager<WeatherResponse> _redisManager;
    private readonly IWeatherApiClient _weatherApiClient;

    public WeatherService(IWeatherApiClient weatherApiClient, IRedisManager<WeatherResponse> redisManager)
    {
        _weatherApiClient = weatherApiClient;
        _redisManager = redisManager;
    }

    public WeatherResponse GetWeather(string city)
    {
        var cachedResponse = _redisManager.GetValue(city);
        if (cachedResponse != null)
            return cachedResponse;
        var apiResponse = _weatherApiClient.GetWeather(city);
        _redisManager.SetValue(city, apiResponse);
        return apiResponse;
    }
}