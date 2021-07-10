using iikoWeather.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace iikoWeather
{
    

    public partial class Window1 : Window
    {

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        private DispatcherTimer aTimer;
        public Window1()
        {
            SetForegroundWindow(new WindowInteropHelper(this).Handle);
            InitializeComponent();
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
            
            string data;
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
        }
    }
}
