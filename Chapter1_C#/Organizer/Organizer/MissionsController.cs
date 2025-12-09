using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Organizer
{
    internal class MissionsController : IDisposable
    {
        private readonly List<Mission> _missions;
        private readonly string _fileString = "C:\\RoadmapLearn\\Chapter1_C#\\Organizer\\Organizer\\Missions.json";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions() 
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
        };

        public MissionsController() 
        {
            _missions = ReadMissionsFromFile().Result;
        }

        private async Task WriteMissionsToFile() 
        {
            using FileStream fs = new FileStream(_fileString, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync<List<Mission>>(fs, _missions, _options);
            Console.WriteLine("Data saved to file");
        }
        public async Task WriteMissionToFile(Mission mission) 
        {
            _missions.Add(mission);
            await WriteMissionsToFile();
        }
        public async Task<List<Mission>> ReadMissionsFromFile() 
        {
            using FileStream fs = new FileStream(_fileString, FileMode.OpenOrCreate);
            List<Mission>? missions = await JsonSerializer.DeserializeAsync<List<Mission>>(fs);
            Console.WriteLine($"Из файла было прочитано {missions.Count} задач");
            return missions;
        }

        public string GetMissionsOrderedByDate() 
        {
            List<Mission> newMissions = _missions.OrderBy(m => m.Date).ToList();
            return MissionsToString(newMissions);
        }
        public string GetMissionByName(string name) 
        {
            Mission currentMission = _missions.FirstOrDefault(m => m.Name == name);
            return $"{currentMission.Id}:{currentMission.Name}:{currentMission.Description}:{currentMission.Date}\n";
        }

        public override string ToString()
        {
            string returnString = string.Empty;
            foreach(Mission mission in _missions) 
            {
                returnString += $"{mission.Id}:{mission.Name}:{mission.Description}:{mission.Date}\n";
            }
            return returnString;
        }
        private string MissionsToString(List<Mission> missions) 
        {
            string returnString = string.Empty;
            foreach (Mission mission in missions)
            {
                returnString += $"{mission.Id}:{mission.Name}:{mission.Description}:{mission.Date}\n";
            }
            return returnString;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
