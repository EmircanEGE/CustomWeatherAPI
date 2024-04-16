using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Infastructer.WeatherApi
{
    public class WeatherApiClient : IWeatherApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public WeatherApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public WeatherResponse GetWeather(string location)
        {
            var apiKey = _configuration["WeatherApiKey"];
            using HttpClient client = _httpClientFactory.CreateClient();
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}";
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (!response.IsSuccessStatusCode)
                return null;
            string responseContent = response.Content.ReadAsStringAsync().Result;
            WeatherApiResponse apiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(responseContent);
            return WeatherResponse.ConvertToWeatherResponse(apiResponse);
        }
    }
}