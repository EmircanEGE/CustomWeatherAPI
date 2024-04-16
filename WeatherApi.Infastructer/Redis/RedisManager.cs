using Newtonsoft.Json;
using StackExchange.Redis;

namespace WeatherApi.Infastructer.Redis;

public class RedisManager<T> : IRedisManager<T> where T : class
{
    private readonly IDatabase _cache;
    private readonly IConnectionMultiplexer _redisConnection;

    public RedisManager(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
        _cache = redisConnection.GetDatabase();
    }

    public T GetValue(string key)
    {
        string cachedData = _cache.StringGet(key);
        if (!string.IsNullOrEmpty(cachedData)) return JsonConvert.DeserializeObject<T>(cachedData);
        return null;
    }

    public void SetValue(string key, T value)
    {
        var serilizedValue = JsonConvert.SerializeObject(value);
        _cache.StringSet(key, serilizedValue, TimeSpan.FromMinutes(10));
    }
}