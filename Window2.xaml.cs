using JetBrains.Annotations;
using Resto.Front.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace iikoWeather
{
    [UsedImplicitly]
    [PluginLicenseModuleId(21016318)]
    public partial class Window2 : Window
    {
        private DispatcherTimer aTimer;
        public Window2()
        {
            InitializeComponent();
        }
        public void Weather()
        {
            GetWeather();
            aTimer = new DispatcherTimer();
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Interval = TimeSpan.FromSeconds(1); //300 seconds = 5 minutes
            aTimer.Start();
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            GetWeather();
        }
        public void GetWeather()
        {

            //string data;
            //string url = "https://api.openweathermap.org/data/2.5/weather?q=Saint+Petersburg&units=metric&appid=f635a4a5f497a9b8a43ac6a232f014d9";
            //WebRequest weatherRequest = WebRequest.Create(url);
            //WebResponse weatherResponse = weatherRequest.GetResponse();
            //using (StreamReader read = new StreamReader(weatherResponse.GetResponseStream()))
            //{
            //    data = read.ReadToEnd();
            //}
            //WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(data);
            //txtBox.Text = $"{weather.Name} \n {weather.Main.Temp} °C";
            
            txtBox.Text = $"{DateTime.Now}";
            popText.Text = $"{DateTime.UtcNow}";
        }
    }
}
