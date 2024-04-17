using Microsoft.EntityFrameworkCore;
using WeatherApi.Application.Dtos;
using WeatherApi.Data;
using WeatherApi.Data.Repositories;

namespace WeatherApi.Application.Services;

public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
    {
        _districtRepository = districtRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DistrictDto> GetById(int id)
    {
        var district = await _districtRepository.Get(x => x.Id == id).FirstOrDefaultAsync();
        if (district == null) return new DistrictDto();
        return DistrictDto.Map(district);
    }

    public async Task<List<DistrictDto>> Get(string name)
    {
        var districts = _districtRepository.Get(x => true);
        if (!string.IsNullOrEmpty(name)) districts = districts.Where(x => x.Name == name);
        return districts.Select(x => DistrictDto.Map(x)).ToList();
    }
}