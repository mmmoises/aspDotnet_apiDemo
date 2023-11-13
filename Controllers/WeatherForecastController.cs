using Microsoft.AspNetCore.Mvc;

namespace apiweb.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> MainlistWC;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(MainlistWC == null || !MainlistWC.Any() ){
            MainlistWC = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("log generado en GET");
        return MainlistWC;
    }

    [HttpPost]

    public IActionResult Post(WeatherForecast wf){

        MainlistWC.Add(wf);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Deleted(int index,int si){

        System.Diagnostics.Debug.WriteLine(si);

        MainlistWC.RemoveAt(index);

        return Ok();
    }
}
