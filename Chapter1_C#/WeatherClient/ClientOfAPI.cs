using System;
using System.Collections.Generic;
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
            _connectionString = $"http://api.openweathermap.org/data/2.5/forecast?id={_moscowId}&appid={_apiKey}";
        }

        public async Task<string> GetWeatherJson() 
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_connectionString);
                return response.Content.ToString();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
