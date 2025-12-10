using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace WeatherClient
{
    internal class WeatherController
    {
        private readonly ClientOfAPI _client;
        private readonly JsonWorker _jsonWorker;
        
        public WeatherController() 
        {
            _client = new ClientOfAPI();
            _jsonWorker = new JsonWorker();
        }

        public async Task<WeatherResponse> GetWeather() 
        {
            Stream stream = await _client.GetWeatherStream();
            WeatherResponse response = await _jsonWorker.GetWeatherFromStream<WeatherResponse>(stream);

            return response;
        }
    }
}
