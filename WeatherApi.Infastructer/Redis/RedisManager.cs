using StackExchange.Redis;

namespace WeatherApi.Infastructer.Redis;

public class RedisManager : IRedisManager
{
    private readonly IDatabase _cache;
    private readonly IConnectionMultiplexer _redisConnection;

    public RedisManager(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
        _cache = redisConnection.GetDatabase();
    }

    public async Task<RedisValue> GetAsync(string key)
    {
        return await _cache.StringGetAsync(key);
        
    }

    public async Task SetAsync(string key, string value, TimeSpan expireTime)
    {
        await _cache.StringSetAsync(key, value, expireTime);
    }
}