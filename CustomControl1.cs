using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace iikoWeather
{
        
    public class CustomControl1 : Control
    {
        
        static CustomControl1()
        {
            
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                double timeUpdate = double.Parse(Properties.Settings.Default.UpdateTime);
                var win = new Window2();
                win.Owner = Application.Current.MainWindow;
                win.GetWeather();
                win.Show();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += Update;
                timer.Interval = TimeSpan.FromMinutes(timeUpdate);
                timer.Start();
            
            void Update(object sender, EventArgs e)
            {
                win.GetWeather();
            }
            });
        }
    }
}