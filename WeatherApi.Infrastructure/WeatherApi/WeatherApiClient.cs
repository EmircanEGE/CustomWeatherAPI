using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Infrastructure.WeatherApi.Models;

namespace WeatherApi.Infrastructure.WeatherApi;

public class WeatherApiClient : IWeatherApiClient
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<WeatherResponse> GetWeather(string location)
    {
        var apiKey = _configuration["WeatherApiKey"];
        using var client = _httpClientFactory.CreateClient();
        var apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}";
        var response = await client.GetAsync(apiUrl);
        if (!response.IsSuccessStatusCode)
            return null;
        var responseContent = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(responseContent);
        return WeatherResponse.ConvertToWeatherResponse(apiResponse);
    }
}