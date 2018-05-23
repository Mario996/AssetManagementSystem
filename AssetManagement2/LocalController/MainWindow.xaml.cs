using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LocalController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<LocalDevice> LocalDeviceList { get; set; }
        public static ObservableCollection<LocalController.Classes.LocalController> LocalControllerList { get; set; }
        //public static List<string> localControllersIds = new List<string>();
        public static ObservableCollection<string> localControllersIds { get; set; }
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            LocalDeviceList = new ObservableCollection<LocalDevice>();
            LocalControllerList = new ObservableCollection<Classes.LocalController>();
            localControllersIds = new ObservableCollection<string>();
            DataContext = this;
            ChangeValue();
        }

        private void ChangeValue()
        {
            var thread1 = new Thread(() =>
            {
                while (true)
                {
                    lock (LocalDeviceList)
                    {
                        foreach (LocalDevice ld in LocalDeviceList)
                        {
                            if (ld.LocalDeviceState)
                            {
                                if (ld.LocalDeviceType.Equals("Digital"))
                                {
                                    ld.LocalDeviceValue = rand.Next(0, 2);
                                    ld.LocalDeviceValues.Add(ld.LocalDeviceValue);

                                }
                                else
                                {
                                    ld.LocalDeviceValue = rand.Next(210, 240);
                                    ld.LocalDeviceValues.Add(ld.LocalDeviceValue);
                                }
                            }
                        }
                        Thread.Sleep(1000);
                    }
                }
            });
            thread1.IsBackground = true;
            thread1.Start();

        }

        private void AddNewDevice_Click(object sender, RoutedEventArgs e)
        {
            
            LocalDeviceAddWindow addWindow = new LocalDeviceAddWindow();
            addWindow.ShowDialog();

        }

        private void AddNewController_Click(object sender, RoutedEventArgs e)
        {

            LocalControllerAddWindow addWindow = new LocalControllerAddWindow();
            addWindow.ShowDialog();

        }

        private void DeleteDevice_Click(object sender, RoutedEventArgs e)
        {
            lock (MainWindow.LocalDeviceList)
            {
                MainWindow.LocalDeviceList.RemoveAt(dataGridDevice.SelectedIndex);
                
            }
        }

        private void TurnON_Click(object sender, RoutedEventArgs e)
        {
            lock (LocalDeviceList)
            {
                for (int i = 0; i < LocalDeviceList.Count; i++)
                {
                    if (i == dataGridDevice.SelectedIndex)
                    {
                        LocalDeviceList[i].TurnOn();
                    }
                }
            }
        }

        private void TurnOFF_Click(object sender, RoutedEventArgs e)
        {
            lock (LocalDeviceList)
            {
                for (int i = 0; i < LocalDeviceList.Count; i++)
                {
                    if (i == dataGridDevice.SelectedIndex)
                    {
                        LocalDeviceList[i].TurnOff();
                        
                    }
                }
            }
        }

        private void DeleteController_Click(object sender, RoutedEventArgs e)
        {
            lock (MainWindow.LocalControllerList)
            {
                MainWindow.LocalControllerList.RemoveAt(dataGridController.SelectedIndex);
                MainWindow.localControllersIds.RemoveAt(dataGridController.SelectedIndex);
            }
        }

        private void TurnONController_Click(object sender, RoutedEventArgs e)
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

        private void TurnOFFController_Click(object sender, RoutedEventArgs e)
        {
            lock (LocalControllerList)
            {
                for (int i = 0; i < LocalControllerList.Count; i++)
                {
                    if (i == dataGridController.SelectedIndex)
                    {
                        LocalControllerList[i].TurnOff();
                        foreach (LocalDevice ld in LocalControllerList[i].LocalControllerDevices)
                        {
                             ld.TurnOff();
                        }
                    }
                }
            }
        }
    }
}

