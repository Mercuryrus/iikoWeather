using iikoWeather.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Threading;

namespace iikoWeather
{
    public partial class Window2 : Window
    {
 
        
        
        public Window2()
        {
            InitializeComponent();
        }
        public void GetWeather()
        {
            var timeUpdate = double.Parse(Properties.Settings.Default.UpdateTime);
            string data;            
            string url = "https://api.openweathermap.org/data/2.5/weather?q=Saint+Petersburg&units=metric&appid=f635a4a5f497a9b8a43ac6a232f014d9";
            WebRequest weatherRequest = WebRequest.Create(url);
            WebResponse weatherResponse = weatherRequest.GetResponse();
            using (StreamReader read = new StreamReader(weatherResponse.GetResponseStream()))
            {
                data = read.ReadToEnd();
            }
            WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(data);
            
            popText.Text = $"{weather.Name}\n {weather.Main.Temp} °C";

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();
            weatherPop.IsOpen = true;
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