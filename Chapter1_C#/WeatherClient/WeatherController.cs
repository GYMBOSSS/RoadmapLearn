using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace WeatherClient
{
    public class WeatherController
    {
        private readonly ClientOfAPI _client;
        private readonly JsonWorker _jsonWorker;
        
        public WeatherController() 
        {
            _client = new ClientOfAPI();
            _jsonWorker = new JsonWorker();

            Console.WriteLine();
        }

        public async Task<WeatherResponse> GetWeather() 
        {
            string? jsonWeatherString = await _client.GetWeatherJsonString();

            WeatherResponse response = _jsonWorker.GetWeatherFromJsonString(jsonWeatherString);
            await _jsonWorker.SerializeToFile(response);

            return response;
        }
    }
}
