using WeatherApi.Application.Dtos;

namespace WeatherApi.Application.Services;

public interface IDistrictService
{
    Task<DistrictDto> GetById(int id);
    Task<List<DistrictDto>> Get(string name);
}