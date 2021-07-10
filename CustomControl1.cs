using JetBrains.Annotations;
using Resto.Front.Api.Attributes;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace iikoWeather
{
    [UsedImplicitly]
    [PluginLicenseModuleId(21016318)]
    
    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
            //Task.Run(() => Application.Current.Dispatcher.InvokeAsync(() =>
            //{
            //    var process = Process.GetCurrentProcess();
            //    var appwin = Application.Current.MainWindow;
            //    var win = new UserControl1();
            //    foreach (Window window in Application.Current.Windows)
            //        ((UserControl1)win).Weather();
            //}));
            var process = Process.GetCurrentProcess();



        Application.Current.Dispatcher.InvokeAsync(() =>
            {
                var win = new Window2();
                win.WeatherPopup.PlacementTarget = Application.Current.MainWindow;
                win.Weather();
                win.Show();
            });
        }

    }
}
