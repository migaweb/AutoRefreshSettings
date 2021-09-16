using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRefreshSettings.Shared
{
  public class WeatherForecast
  {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public OptionSettings OptionSettings { get; set; }

    public OptionSnapshotSettings OptionSnapshotSettings { get; set; }

    public OptionMonitorSettings OptionMonitorSettings { get; set; }
  }
}
