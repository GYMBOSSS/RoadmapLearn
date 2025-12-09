using Organizer.Models;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;

namespace Organizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MissionsController controller = new MissionsController();
            AnsiConsole.Markup("[underline red]Hello World![/]");
            while (true)
            {
                Console.WriteLine("1.Вывести список задач\n2.Добавить задачу\n3.Вывести список задач отсортированный по датам\n4.Найти задание по имени");
                string switcher = Console.ReadLine();
                switch (switcher)
                {
                    case "1":
                        Console.WriteLine("Список задач:");
                        Console.WriteLine(controller.ToString());
                        break;
                    case "2":
                        Console.WriteLine("Введи id");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введи имя");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введи описание");
                        string description = Console.ReadLine();
                        Console.WriteLine("Введи год");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введи месяц");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введи день");
                        int day = int.Parse(Console.ReadLine());

                        Mission nm = new Mission()
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            Date = new DateTime(year, month, day)
                        };
                        controller.WriteMissionToFile(nm);
                        break;
                    case "3":
                        Console.WriteLine(controller.GetMissionsOrderedByDate());
                        break;
                    case "4":
                        string currentName = Console.ReadLine();
                        Console.WriteLine(controller.GetMissionByName(currentName));
                        break;
                }
            }
        }
    }
}
