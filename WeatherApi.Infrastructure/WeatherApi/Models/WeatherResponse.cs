namespace WeatherApi.Infrastructure.WeatherApi.Models;

public class WeatherResponse
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public double Temperature { get; set; }
    public string Description { get; set; }

    public static WeatherResponse ConvertToWeatherResponse(WeatherApiResponse apiResponse)
    {
        return new WeatherResponse
        {
            Name = apiResponse.Location.Name,
            Region = apiResponse.Location.Region,
            Country = apiResponse.Location.Country,
            Latitude = apiResponse.Location.Lat,
            Longitude = apiResponse.Location.Lon,
            Temperature = apiResponse.Current.TempC,
            Description = apiResponse.Current.Condition.Text
        };
    }
}