using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WeatherClient
{
    class JsonWorker
    {
        ClientOfAPI api;
        JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            WriteIndented = true
        };
        string jsonFile = "C:\\RoadmapLearn\\Chapter1_C#\\WeatherClient\\Weather.json";
        public JsonWorker()
        {
            api = new ClientOfAPI();
        }

        public WeatherResponse GetWeatherFromJsonString(string str) 
        {
            WeatherResponse response = JsonConvert.DeserializeObject<WeatherResponse>(str);
        
            return response;
        }

        public async Task SerializeToFile(WeatherResponse response) 
        {
            File.WriteAllText(jsonFile, JsonConvert.SerializeObject(response));
        }
    }
}
