using Microsoft.AspNetCore.Mvc;
using WeatherApi.Application.Services;

namespace WeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var district = await _districtService.GetById(id);
        return Ok(district);
    }

    [HttpGet("{district}")]
    public async Task<IActionResult> Get(string district)
    {
        var districts = await _districtService.Get(district);
        if (districts != null) return Ok(districts);
        return NotFound($"İlçe bulunamadı: {district}");
    }
}