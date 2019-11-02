using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenEnrique.ProxyServices;

namespace ExamenEnrique.Classes
{
    public class AdapterForecastWeather
    {
        public WeatherObject forecastToWeather(Forecast f, int index)
        {
            WeatherObject weather = new WeatherObject {name=f.city.name,main=f.list[index].main };
            return weather;
        }
        
    }
}
