using Domain.Models;

namespace BlazorWasm.Services;

public interface IWeatherService
{
    public Task<IEnumerable<WeatherForecast>> GetWeather();
}