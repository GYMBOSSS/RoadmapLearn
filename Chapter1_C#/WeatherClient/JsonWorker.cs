using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
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

        public async Task<T> GetWeatherFromStream<T>(Stream stream) 
        {
            T response;
            response = await JsonSerializer.DeserializeAsync<T>(stream, options);
           
            await SerializeToFile<T>(response);

            return response;
        }
        public async Task SerializeToFile<T>(T response) 
        {
            Stream stream = new FileStream(jsonFile, FileMode.OpenOrCreate);
            JsonSerializer.Serialize(stream, response, options);
        }
    }
}
