using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
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
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = Assembly.GetExecutingAssembly().Location + ".config";
                Configuration libConfig = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                AppSettingsSection section = libConfig.GetSection("appSettings") as AppSettingsSection;
                double timeUpdate = double.Parse(section.Settings["UpdateTime"].Value);

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