using System;
using System.Diagnostics;
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
            Window window = new Window2();
            window.ShowActivated = true;

            //HwndSourceParameters parameters = new HwndSourceParameters();
            //parameters.WindowStyle = 0x10000000 | 0x40000000;
            //parameters.SetPosition(0, 0);
            //parameters.SetSize((int)window.Width, (int)window.Height);
            //parameters.ParentWindow = Process.GetCurrentProcess().MainWindowHandle;
            //parameters.UsesPerPixelOpacity = true;
            //HwndSource src = new HwndSource(parameters);
            //src.CompositionTarget.BackgroundColor = Colors.Transparent;
            //src.RootVisual = (Visual)window.Content;

            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                var win = new Window2();
                win.Show();
            });
        }
    }
}