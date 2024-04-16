using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Infastructer.WeatherApi;

public class WeatherApiClient : IWeatherApiClient
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public WeatherResponse GetWeather(string location)
    {
        var apiKey = _configuration["WeatherApiKey"];
        using var client = _httpClientFactory.CreateClient();
        var apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}";
        var response = client.GetAsync(apiUrl).Result;
        if (!response.IsSuccessStatusCode)
            return null;
        var responseContent = response.Content.ReadAsStringAsync().Result;
        var apiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(responseContent);
        return WeatherResponse.ConvertToWeatherResponse(apiResponse);
    }
}