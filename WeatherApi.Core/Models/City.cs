namespace WeatherApi.Data.Models;

public class City : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<District> Districts { get; set; }
}