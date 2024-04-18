using Microsoft.EntityFrameworkCore;
using WeatherApi.Application.Dtos;
using WeatherApi.Data;
using WeatherApi.Data.Models;
using WeatherApi.Data.Repositories;

namespace WeatherApi.Application.Services;

public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;

    public DistrictService(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<DistrictDto> GetById(int id)
    {
        var district = await _districtRepository.Get(x => x.Id == id).Include(x => x.City).FirstOrDefaultAsync();
        if (district == null) return new DistrictDto();
        return DistrictDto.Map(district);
    }

    public async Task<List<DistrictDto>> Get(int? id, int? cityId, string name)
    {
        var districts = _districtRepository.Get(x => true, i => i.City);
        if (!string.IsNullOrEmpty(name))
        {
            districts = districts.Where(x => x.Name == name);
        }
        if (id != null)
        {
            districts = districts.Where(x => x.Id == id);
        }
        if (cityId != null)
        {
            districts = districts.Where(x => x.CityId == cityId);
        }
        return districts.Include(x => x.City).Select(x => DistrictDto.Map(x)).ToList();
    }
}