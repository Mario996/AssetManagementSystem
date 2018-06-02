using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LocalController
{
    /// <summary>
    /// Interaction logic for LocalDeviceAddWindow.xaml
    /// </summary>
    public partial class LocalDeviceAddWindow : Window
    {
        public static List<string> typeList = new List<string>() { "Digital", "Analog" };
        public static List<string> destinationList = new List<string>() { "Local controller", "AMS" };

        public LocalDeviceAddWindow()
        {
            InitializeComponent();
            comboBoxType.ItemsSource = typeList;
            comboBoxDestination.ItemsSource = destinationList;
            comboBoxController.ItemsSource = MainWindow.localControllersIds;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                lock (MainWindow.LocalDeviceList)
                {
                    foreach(LocalDevice ld in LocalController.MainWindow.LocalDeviceList)
                    {
                        if(textBoxCode.Text.Equals(ld.LocalDeviceCode))
                        {
                            textBoxCode.Text = textBoxCode.GetHashCode().ToString(); //ukoliko ime vec postoji, ime ovog LD-a postaje hash code
                            break;
                        }
                    }

                    LocalDevice dev = new LocalDevice(textBoxCode.Text ,Double.Parse(textBoxPeriod.Text), Int32.Parse(textBoxLimit.Text), comboBoxType.SelectedItem.ToString(), comboBoxDestination.SelectedItem.ToString(),comboBoxController.SelectedItem.ToString());
                    MainWindow.LocalDeviceList.Add(dev);

                    foreach(LocalController.Classes.LocalController lc in MainWindow.LocalControllerList)
                    {
                        if (lc.LocalControllerCode.Equals(comboBoxController.SelectedItem.ToString()))
                        {
                            lc.LocalControllerDevices.Add(dev);
                        }
                    }
                    
                    this.Close();
                }
            }
        }

        private bool Validate()
        {
            bool result = true;

            if (textBoxPeriod.Text.Trim().Equals(String.Empty))
            {
                result = false;
                LabelPeriodGreska.Content = "Enter the field value!";
                textBoxPeriod.BorderBrush = Brushes.Red;
                textBoxPeriod.BorderThickness = new Thickness(2);
            }
            else
            {
                try
                {
                    double period = Double.Parse(textBoxPeriod.Text.Trim());

                    if (period < 0)
                    {
                        result = false;
                        LabelPeriodGreska.Content = "Field value is incorrect!";
                        textBoxPeriod.BorderBrush = Brushes.Red;
                        textBoxPeriod.BorderThickness = new Thickness(2);
                    }
                }
                catch (Exception)
                {
                    result = false;
                    LabelPeriodGreska.Content = "Field value is incorrect!";
                    textBoxPeriod.BorderBrush = Brushes.Red;
                    textBoxPeriod.BorderThickness = new Thickness(2);
                }
            }

            if (textBoxLimit.Text.Trim().Equals(String.Empty))
            {
                result = false;
                LabelLimitGreska.Content = "Enter the field value!";
                textBoxLimit.BorderBrush = Brushes.Red;
                textBoxLimit.BorderThickness = new Thickness(2);
            }
            else
            {
                try
                {
                    int limit = Int32.Parse(textBoxPeriod.Text.Trim());

                    if (limit < 0)
                    {
                        result = false;
                        LabelLimitGreska.Content = "Field value is incorrect!";
                        textBoxLimit.BorderBrush = Brushes.Red;
                        textBoxLimit.BorderThickness = new Thickness(2);
                    }
                }
                catch (Exception)
                {
                    LabelLimitGreska.Content = "Field value is incorrect!";
                    textBoxLimit.BorderBrush = Brushes.Red;
                    textBoxLimit.BorderThickness = new Thickness(2);
                }
            }

            if (comboBoxType.SelectedItem == null)
            {
                result = false;
                LabelTypeGreska.Content = "Choose the type of device";
                comboBoxType.BorderBrush = Brushes.Red;
                comboBoxType.BorderThickness = new Thickness(2);
            }
            else
            {
                LabelTypeGreska.Content = String.Empty;
                comboBoxType.BorderBrush = Brushes.Transparent;
            }

            if (comboBoxDestination.SelectedItem == null)
            {
                result = false;
                LabelDestGreska.Content = "Choose a destionation\nfor sending data!";
                comboBoxDestination.BorderBrush = Brushes.Red;
                comboBoxDestination.BorderThickness = new Thickness(2);
            }
            else
            {
                LabelDestGreska.Content = String.Empty;
                comboBoxDestination.BorderBrush = Brushes.Transparent;
            }

            return result;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

