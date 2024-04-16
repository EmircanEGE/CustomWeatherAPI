namespace WeatherApi.Infastructer.WeatherApi.Models
{
    public class WeatherApiResponse
    {
        public CurrentWeather Current { get; set; }
        public LocationWeather Location { get; set; }
    }
}