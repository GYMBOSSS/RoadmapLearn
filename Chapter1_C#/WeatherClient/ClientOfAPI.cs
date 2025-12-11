using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WeatherClient
{
    class ClientOfAPI
    {
        private HttpClient _client;
        private string _apiKey = "99f3178ce572598bb30637ab56b96754";
        private string _moscowId = "569842";

        private string _connectionString;

        public ClientOfAPI() 
        {
            _client = new HttpClient();
            _connectionString = $"http://api.openweathermap.org/data/2.5/weather?id={_moscowId}&appid={_apiKey}";
        }

        public async Task<string?> GetWeatherJsonString() 
        {    
            using HttpResponseMessage response = await _client.GetAsync(_connectionString);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            else 
            {
                Console.WriteLine("Server's response have unsuccess status code");
                return null;
            }
        }
    }
}
