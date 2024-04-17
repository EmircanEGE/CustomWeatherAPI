using Microsoft.EntityFrameworkCore.Storage;

namespace WeatherApi.Data;

public interface IUnitOfWork
{
    Task CommitAsync(IDbContextTransaction transaction);
    Task<IDbContextTransaction> CreateTransactionAsync();
    Task SaveChangesAsync();
}