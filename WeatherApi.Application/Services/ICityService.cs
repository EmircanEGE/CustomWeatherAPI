using WeatherApi.Application.Dtos;

namespace WeatherApi.Application.Services;

public interface ICityService
{
    Task<CityDto> GetById(int id);
    Task<List<CityDto>> Get(string name);
}