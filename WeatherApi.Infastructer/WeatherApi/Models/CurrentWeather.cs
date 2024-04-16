namespace WeatherApi.Infastructer.WeatherApi.Models;

public class CurrentWeather
{
    public double Temp_C { get; set; }
    public Condition Condition { get; set; }
}