using WeatherApi.Data.Models;

namespace WeatherApi.Data.Repositories;

public class DistrictRepository : Repository<District>, IDistrictRepository
{
    public DistrictRepository(Context context) : base(context)
    {
    }
}