using System.Linq.Expressions;

namespace WeatherApi.Data.Repositories;

public interface IRepository<T>
{
    IQueryable<T> Get(Expression<Func<T, bool>> expression);
}