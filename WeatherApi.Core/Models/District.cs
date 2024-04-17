using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApi.Data.Models;

public class District : BaseEntity
{
    public string Name { get; set; }
    [ForeignKey("City")] public int CityId { get; set; }

    public virtual City City { get; set; }
}