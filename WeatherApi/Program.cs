using StackExchange.Redis;
using WeatherApi.Application.Services;
using WeatherApi.Infastructer.Redis;
using WeatherApi.Infastructer.WeatherApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
    string redisConnectionString = configuration.GetConnectionString("Redis");
    return ConnectionMultiplexer.Connect(redisConnectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRedisManager, RedisManager>();
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IWeatherApiClient, WeatherApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();