using AutoRefreshSettings.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRefreshSettings.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOptions<OptionSettings> _optionSettings;
    private readonly IOptionsSnapshot<OptionSnapshotSettings> _optionsSnapshot;
    private readonly IOptionsMonitor<OptionMonitorSettings> _optionMonitor;
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
      IOptions<OptionSettings> optionSettings,
      IOptionsSnapshot<OptionSnapshotSettings> optionSnapshot,
      IOptionsMonitor<OptionMonitorSettings> optionMonitor)
    {
      _logger = logger;
      _optionSettings = optionSettings;
      _optionsSnapshot = optionSnapshot;
      _optionMonitor = optionMonitor;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)],
        OptionSettings = _optionSettings.Value,
        OptionSnapshotSettings = _optionsSnapshot.Value,
        OptionMonitorSettings = _optionMonitor.CurrentValue
      })
      .ToArray();
    }
  }
}
