using Newtonsoft.Json;

namespace WeatherApi.Infrastructure.WeatherApi.Models;

public class CurrentWeather
{
    [JsonProperty("Temp_c")] public double TempC { get; set; }

    public Condition Condition { get; set; }
}