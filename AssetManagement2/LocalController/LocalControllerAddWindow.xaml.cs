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
    /// Interaction logic for LocalControllerAddWindow.xaml
    /// </summary>
    public partial class LocalControllerAddWindow : Window
    {
        public LocalControllerAddWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                double period = Double.Parse(TextBoxPeriod.Text);
                LocalController.Classes.LocalController lc = new Classes.LocalController(TextBoxCode.Text,period);
                MainWindow.LocalControllerList.Add(lc);
                MainWindow.localControllersIds.Add(lc.LocalControllerCode);
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            bool result = true;

            if (TextBoxPeriod.Text.Trim().Equals(String.Empty))
            {
                result = false;
                LabelPeriodGreska.Content = "Enter the field value!";
                TextBoxPeriod.BorderBrush = Brushes.Red;
                TextBoxPeriod.BorderThickness = new Thickness(2);
            }
            else
            {
                try
                {
                    double period = Double.Parse(TextBoxPeriod.Text.Trim());

                    if (period < 0)
                    {
                        result = false;
                        LabelPeriodGreska.Content = "Field value is incorrect!";
                        TextBoxPeriod.BorderBrush = Brushes.Red;
                        TextBoxPeriod.BorderThickness = new Thickness(2);
                    }
                }
                catch (Exception)
                {
                    result = false;
                    LabelPeriodGreska.Content = "Field value is incorrect!";
                    TextBoxPeriod.BorderBrush = Brushes.Red;
                    TextBoxPeriod.BorderThickness = new Thickness(2);
                }
            }

            if (TextBoxCode.Text.Trim().Equals(String.Empty))
            {
                result = false;
                LabelCodeGreska.Content = "Enter the field value!";
                TextBoxPeriod.BorderBrush = Brushes.Red;
                TextBoxPeriod.BorderThickness = new Thickness(2);
            }
            return result;
        }
    }
}
