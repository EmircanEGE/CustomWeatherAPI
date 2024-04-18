using Newtonsoft.Json;
using WeatherApi.Data.Repositories;
using WeatherApi.Infrastructure.Redis;
using WeatherApi.Infrastructure.WeatherApi;
using WeatherApi.Infrastructure.WeatherApi.Models;

namespace WeatherApi.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IRedisManager _redisManager;
    private readonly IWeatherApiClient _weatherApiClient;
    private readonly IDistrictRepository _districtRepository;
    private readonly ICityRepository _cityRepository;

    public WeatherService(IWeatherApiClient weatherApiClient, IRedisManager redisManager, ICityRepository cityRepository, IDistrictRepository districtRepository)
    {
        _weatherApiClient = weatherApiClient;
        _redisManager = redisManager;
        _cityRepository = cityRepository;
        _districtRepository = districtRepository;
    }

    public async Task<WeatherResponse> GetWeather(string city, int? cityId, int? districtId)
    {
        string cityName = city;
        if (cityId != null)
        {
            var dbCity = _cityRepository.Get(x => x.Id == cityId).FirstOrDefault();
            if (dbCity != null)
            {
                cityName = dbCity.Name;
            }
        }
        else if (districtId != null)
        {
            var dbDistrict = _districtRepository.Get(x => x.Id == districtId).FirstOrDefault();
            if (dbDistrict != null)
            {
                cityName = dbDistrict.Name;
            }
        }

        var cachedResponse = await _redisManager.GetAsync(cityName);
        if (!string.IsNullOrEmpty(cachedResponse))
            return JsonConvert.DeserializeObject<WeatherResponse>(cachedResponse);

        var apiResponse = await _weatherApiClient.GetWeather(cityName);
        var serializedResponse = JsonConvert.SerializeObject(apiResponse);
        await _redisManager.SetAsync(cityName, serializedResponse, TimeSpan.FromMinutes(10));
        return apiResponse;
    }
}