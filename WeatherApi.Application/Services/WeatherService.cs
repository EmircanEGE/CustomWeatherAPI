using Newtonsoft.Json;
using WeatherApi.Infrastructure.Redis;
using WeatherApi.Infrastructure.WeatherApi;
using WeatherApi.Infrastructure.WeatherApi.Models;

namespace WeatherApi.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IRedisManager _redisManager;
    private readonly IWeatherApiClient _weatherApiClient;

    public WeatherService(IWeatherApiClient weatherApiClient, IRedisManager redisManager)
    {
        _weatherApiClient = weatherApiClient;
        _redisManager = redisManager;
    }

    public async Task<WeatherResponse> GetWeather(string city)
    {
        var cachedResponse = await _redisManager.GetAsync(city);
        if (cachedResponse.HasValue && !string.IsNullOrEmpty(cachedResponse))
            return JsonConvert.DeserializeObject<WeatherResponse>(cachedResponse);
        var apiResponse = await _weatherApiClient.GetWeather(city);
        var serializedResponse = JsonConvert.SerializeObject(apiResponse);
        await _redisManager.SetAsync(city, serializedResponse, TimeSpan.FromMinutes(10));
        return apiResponse;
    }
}