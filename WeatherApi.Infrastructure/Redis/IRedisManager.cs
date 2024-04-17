using StackExchange.Redis;

namespace WeatherApi.Infrastructure.Redis;

public interface IRedisManager
{
    Task<RedisValue> GetAsync(string key);
    Task SetAsync(string key, string value, TimeSpan expireTime);
}