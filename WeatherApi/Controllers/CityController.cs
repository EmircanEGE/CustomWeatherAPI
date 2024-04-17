using Microsoft.AspNetCore.Mvc;
using WeatherApi.Application.Services;

namespace WeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetbyId([FromRoute] int id)
    {
        var city = await _cityService.GetById(id);
        return Ok(city);
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> Get(string city)
    {
        var cities = await _cityService.Get(city);
        if (cities != null) return Ok(cities);
        return NotFound($"İl bulunamadı: {city}");
    }
}