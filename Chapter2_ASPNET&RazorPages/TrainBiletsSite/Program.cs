using Microsoft.AspNetCore.Razor;

namespace TrainBiletsSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages(options => options.RootDirectory = "/MyPages");

            var app = builder.Build();

            app.MapRazorPages();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
