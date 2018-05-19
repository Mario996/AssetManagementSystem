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

namespace LocalController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<LocalDevice> LocalDeviceList { get; set; }

        
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            LocalDeviceList = new ObservableCollection<LocalDevice>();
            
            
            DataContext = this;
            ChangeValue();
        }

        private void ChangeValue()
        {
            var thread1 = new Thread(() =>
            {
                while (true)
                {                   
                    lock(LocalDeviceList)
                    {

                        foreach (LocalDevice ld in LocalDeviceList)
                        {
                            if (ld.LocalDeviceState)
                            {
                                if (ld.LocalDeviceType.Equals("Digital"))
                                {
                                    ld.LocalDeviceValue = rand.Next(0, 2);
                                    LocalController.Classes.LocalController.LocalControllerValuesHistory[ld].Add(ld.LocalDeviceValue);
                                }
                                else
                                {
                                    ld.LocalDeviceValue = rand.Next(210, 240);
                                    LocalController.Classes.LocalController.LocalControllerValuesHistory[ld].Add(ld.LocalDeviceValue);
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

        private void AddNewDevice_Click(object sender, RoutedEventArgs e)
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
                for(int i = 0; i < LocalDeviceList.Count; i++)
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

    }
}
