using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WeatherController weatherController;
        public MainWindow()
        {
            InitializeComponent();
            weatherController = new WeatherController();

            WeatherResponse weather = GetWeather(weatherController).Result;

            Console.ReadLine();
        }
        
        public async Task<WeatherResponse> GetWeather(WeatherController controller) 
        {
            WeatherResponse weatherInMoscow = await weatherController.GetWeather();
            return weatherInMoscow;
        }
    }
}