using iikoWeather.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
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
            string url = "https://api.openweathermap.org/data/2.5/weather?q=Saint+Petersburg&units=metric&appid=f635a4a5f497a9b8a43ac6a232f014d9";
            WebRequest weatherRequest = WebRequest.Create(url);
            WebResponse weatherResponse = weatherRequest.GetResponse();
            string data;
            using (StreamReader read = new StreamReader(weatherResponse.GetResponseStream()))
            {
                data = read.ReadToEnd();
            }
            WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(data);
            
            popText.Text = $"{weather.Name}\n {weather.Main.Temp} °C";
            

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Close;
            timer.Start();
            weatherPop.IsOpen = true;
        }

        private void Close(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= Close;
            weatherPop.IsOpen = false;
        }
    }
}