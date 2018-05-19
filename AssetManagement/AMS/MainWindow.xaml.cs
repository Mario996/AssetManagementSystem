using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<LocalController.Classes.LocalController> LocalControllerList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            LocalControllerList = new ObservableCollection<LocalController.Classes.LocalController>();
            Pokusaj();
        }

        private void dodajLC(object sender, RoutedEventArgs e)
        {
            LocalControllerList.Add(new LocalController.Classes.LocalController(Double.Parse(TextBoxPeriod.Text)));
            LocalController.MainWindow window = new LocalController.MainWindow();
            window.Show();
            //Process.Start("LocalController.exe");
            //LocalController.MainWindow lc = new LocalController.MainWindow();
        }

        private void Pokusaj()
        {

            var thread1 = new Thread(() =>
            {
                while (true)
                {
                    lock (LocalControllerList)
                    {
                        foreach (LocalController.Classes.LocalController lc in LocalControllerList)
                        {
                            if (!lc.LocalControllerState)
                            {
                                foreach (KeyValuePair<LocalDevice, List<int>> kv in LocalController.Classes.LocalController.LocalControllerValuesHistory)
                                {
                                    if (kv.Key.LocalDeviceState)
                                    {
                                        kv.Key.TurnOff();
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void DeleteDevice_Click(object sender, RoutedEventArgs e)
        {
            lock (LocalControllerList)
            {
                LocalControllerList.RemoveAt(dataGridController.SelectedIndex);
            }
        }

        private void TurnON_Click(object sender, RoutedEventArgs e)
        {
            lock (LocalControllerList)
            {
                for (int i = 0; i < LocalControllerList.Count; i++)
                {
                    if (i == dataGridController.SelectedIndex)
                    {
                        LocalControllerList[i].TurnOn();
                    }
                }
            }
        }

        private void TurnOFF_Click(object sender, RoutedEventArgs e)
        {
            lock (LocalControllerList)
            {
                for (int i = 0; i < LocalControllerList.Count; i++)
                {
                    if (i == dataGridController.SelectedIndex)
                    {
                        LocalControllerList[i].TurnOff();
                    }
                }
            }
        }
    }
}
