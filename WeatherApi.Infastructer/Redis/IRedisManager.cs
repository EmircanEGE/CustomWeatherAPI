namespace WeatherApi.Infastructer.Redis;

public interface IRedisManager<T>
{
    T GetValue(string key);
    public void SetValue(string key, T value);
}