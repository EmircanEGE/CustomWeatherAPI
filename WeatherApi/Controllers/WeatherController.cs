using Microsoft.AspNetCore.Mvc;
using WeatherApi.Application.Services;

namespace WeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{city}")]
    public IActionResult GetWeather(string city)
    {
        var weather = _weatherService.GetWeather(city);
        if (weather != null) return Ok(weather);
        return NotFound($"Hava durumu bilgileri bulunamadı: {city}");
    }
}