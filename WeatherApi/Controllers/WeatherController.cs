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

    [HttpGet]
    public async Task<IActionResult> GetWeather(string city, int? cityId, int? districtId)
    {
        var weather = await _weatherService.GetWeather(city, cityId, districtId);
        if (weather != null) return Ok(weather);
        return NotFound($"Hava durumu bilgileri bulunamadı: {city}");
    }
}