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
                //Это код? Это баг? Нет, это ... это полное дерьмо, Эндрю... когда я смогу спать хотя бы по ночам?
                //тестовое тестовое тестовое еще тестовое...
                
                
                var win = new Window2();
                win.Owner = Application.Current.MainWindow;//А насколько важно знание определения и парадигм ООП для разработчика?(вот сейчас правда интересно)
                win.GetWeather();
                win.Show();

                //ну тут таймер.. ваааааууу таймер.. ни*!" ж себе, не вы видели он таймер сделал...
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += Update;
                timer.Interval = TimeSpan.FromMinutes(timeUpdate);
                timer.Start();
            //да я знаю что вы смотрите этот код, да я не учился этому в ВУЗе 5 лет
            //эта жопа в огнееее и нам некуда больше бежать
            //отсылка... мда..
            void Update(object sender, EventArgs e)
            {
                win.GetWeather();
            }
            });
        }
    }
}
