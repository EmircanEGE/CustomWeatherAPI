namespace WeatherApi.Data.Models;

public class City : BaseEntity
{
    public virtual ICollection<District> Districts { get; set; }
}