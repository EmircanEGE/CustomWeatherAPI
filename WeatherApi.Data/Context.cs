using Microsoft.EntityFrameworkCore;
using WeatherApi.Data.Models;

namespace WeatherApi.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
}