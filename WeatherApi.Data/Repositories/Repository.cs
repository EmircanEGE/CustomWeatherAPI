using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Data.Models;

namespace WeatherApi.Data.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public Repository(Context context)
    {
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> expression)
    {
        return _dbSet.AsNoTracking().Where(expression);
    }
}