using WeatherApi.Data.Models;

namespace WeatherApi.Data.Repositories;

public class CityRepository : Repository<City>, ICityRepository
{
    public CityRepository(Context context) : base(context)
    {
    }
}