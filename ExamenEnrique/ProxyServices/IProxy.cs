using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEnrique.ProxyServices
{
    //Codigo usado en la clase de Proxy que vimos en clase cuando debiamos hacer forecasts

    public interface IProxy
    {
        WeatherObject weather(string ciudad);
        Forecast forecast(string ciudad);
    }
}
