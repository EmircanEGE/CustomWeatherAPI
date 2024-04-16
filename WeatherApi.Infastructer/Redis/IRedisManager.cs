using StackExchange.Redis;

namespace WeatherApi.Infastructer.Redis;

public interface IRedisManager
{
    Task<RedisValue> GetAsync(string key);
    Task SetAsync(string key, string value, TimeSpan expireTime);
}