using Microsoft.EntityFrameworkCore;
using WeatherApi.Application.Dtos;
using WeatherApi.Data;
using WeatherApi.Data.Repositories;

namespace WeatherApi.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CityDto> GetById(int id)
    {
        var city = await _cityRepository.GetAsync(x => x.Id == id).FirstOrDefaultAsync();
        if (city == null) return new CityDto();

        return CityDto.Map(city);
    }

    public async Task<List<CityDto>> Get(string name)
    {
        var cities = _cityRepository.GetAsync(x => true);
        if (!string.IsNullOrEmpty(name)) cities = cities.Where(x => x.Name == name);
        return cities.Select(x => CityDto.Map(x)).ToList();
    }
}