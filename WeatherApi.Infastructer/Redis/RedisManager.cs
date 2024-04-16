using Newtonsoft.Json;
using StackExchange.Redis;
using WeatherApi.Infastructer.WeatherApi.Models;

namespace WeatherApi.Infastructer.Redis
{
    public class RedisManager : IRedisManager
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDatabase _cache;

        public RedisManager(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            _cache = redisConnection.GetDatabase();
        }

        public WeatherResponse GetWeather(string location)
        {
            string cachedData = _cache.StringGet(location);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonConvert.DeserializeObject<WeatherResponse>(cachedData);
            }

            return null;
        }

        public void SetWeather(string location, WeatherResponse weather)
        {
            string serilizedWeather = JsonConvert.SerializeObject(weather);
            _cache.StringSet(location, serilizedWeather, TimeSpan.FromMinutes(10));
        }
    }
}