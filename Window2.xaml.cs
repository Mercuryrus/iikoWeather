using iikoWeather.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Threading;

namespace iikoWeather
{
    public partial class Window2 : Window
    {
 
        public string data;
        public string text;
        public Window2()
        {
            InitializeComponent();
            
            txtBox.Text = $"{DateTime.Now}";
            popText.Text = $"{DateTime.UtcNow}";
            DispatcherTimer aTimer;
            aTimer = new DispatcherTimer();
            aTimer.Tick += new EventHandler(GetWeather);
            aTimer.Interval = TimeSpan.FromSeconds(300); //300 seconds = 5 minutes
            aTimer.Start();
        }
        public void GetWeather(object send, EventArgs e)
        {

            string url = "https://api.openweathermap.org/data/2.5/weather?q=Saint+Petersburg&units=metric&appid=f635a4a5f497a9b8a43ac6a232f014d9";
            WebRequest weatherRequest = WebRequest.Create(url);
            WebResponse weatherResponse = weatherRequest.GetResponse();
            using (StreamReader read = new StreamReader(weatherResponse.GetResponseStream()))
            {
                data = read.ReadToEnd();
            }
            WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(data);
            txtBox.Text = $"{weather.Name}\n {weather.Main.Temp} °C";
            popText.Text = $"{weather.Name}\n {weather.Main.Temp} °C";
            text = $"{weather.Name}\n {weather.Main.Temp}";

            weatherPop.IsOpen = true;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += TimerTick;
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            weatherPop.IsOpen = false;
        }
    }
}
