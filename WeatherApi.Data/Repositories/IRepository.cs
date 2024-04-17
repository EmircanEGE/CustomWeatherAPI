using System.Linq.Expressions;

namespace WeatherApi.Data.Repositories;

public interface IRepository<T>
{
    IQueryable<T> GetAsync(Expression<Func<T, bool>> expression);
}