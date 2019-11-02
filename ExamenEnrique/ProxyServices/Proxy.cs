using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
namespace ExamenEnrique.ProxyServices
{
    //Codigo usado en la clase de Proxy que vimos en clase cuando debiamos hacer forecasts

    class Proxy : IProxy
    {
        private RestClient _client;
        private string _appid = "b1e34d4d55487b41db609a28e5854900";
        private string _units = "metric";
        public Proxy()
        {
            _client = new RestClient("http://api.openweathermap.org/data/2.5/");
        }

        public WeatherObject weather(string ciudad)
        {
            var request = new RestRequest($"weather?q={ciudad}&APPID={_appid}&units={_units}");
            var response = _client.Get<WeatherObject>(request);
            return response.Data;
        }
        public Forecast forecast(string ciudad)
        {
            var request = new RestRequest($"forecast?q={ciudad}&APPID={_appid}&units={_units}");
            var response = _client.Get<Forecast>(request);
            return response.Data;

        }
    }
}
