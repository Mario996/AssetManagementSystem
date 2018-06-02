using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static List<string> devices = new List<string>();
        private static List<string> ListaVrednosti { get; set; }
        private static List<int> ListValue { get; set; }
        private static List<DateTime> ListTime { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListaVrednosti = new List<string>();
            ListValue = new List<int>();
            ListTime = new List<DateTime>();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {

            //01-Jun-18 19:29:42
            DateTime dateTimeStart = DateTime.ParseExact(textBoxStart.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);
            DateTime dateTimeEnd = DateTime.ParseExact(textBoxEnd.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);

            string path = "../../../AMS/bin/Debug/Controllers/ams.xml";

            XDocument doc = XDocument.Load(path);
            IEnumerable<XElement> elements = (from el in doc.Descendants("device") where (string)el.Attribute("code").Value == textBoxLD.Text.ToString() select el); //ovde su svi device
            IEnumerable<XElement> values = (from el in elements.Descendants("value") select el); //ovde su sve vrednosti

            foreach (XElement xe in values)
            {
                if (DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) >= dateTimeStart && DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) <= dateTimeEnd)
                    ListaVrednosti.Add("Value: " + xe.Value + " time: " + xe.FirstAttribute.Value); //ovde ubacujemo one vrednosti koje upadaju u vreme izmedju
            }

            textBoxReport.Text = String.Join(Environment.NewLine, ListaVrednosti);
            ListaVrednosti.Clear();
            doc.Save(path);
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {

            DateTime dateTimeStart = DateTime.ParseExact(textBoxStart2.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);
            DateTime dateTimeEnd = DateTime.ParseExact(textBoxEnd2.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);

            string path = "../../../AMS/bin/Debug/Controllers/ams.xml";

            XDocument doc = XDocument.Load(path);
            IEnumerable<XElement> elements = (from el in doc.Descendants("device") where (string)el.Attribute("code").Value == textBoxLD2.Text.ToString() select el); //ovde su svi device
            IEnumerable<XElement> values = (from el in elements.Descendants("value") select el); //ovde su sve vrednosti


            foreach (XElement xe in values)
            {
                if (DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) >= dateTimeStart && DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) <= dateTimeEnd)
                {
                    ListValue.Add(Int32.Parse(xe.Value)); //ovde ubacujemo one vrednosti koje upadaju u vreme izmedju
                    ListTime.Add(DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None));
                }  
            }

            int countTemp = ListValue.Count;
            int countTime = ListTime.Count;

            List<KeyValuePair<DateTime, int>> data1 = new List<KeyValuePair<DateTime, int>>();

           if (countTemp == countTime)
           {
              for (int i = 0; i < countTemp; i++)
              {
                  KeyValuePair<DateTime, int> dt = new KeyValuePair<DateTime, int>(ListTime[i], ListValue[i]);
                  data1.Add(dt);
              }
           }

           series.ItemsSource = data1;
                
            ListValue.Clear();
            ListTime.Clear();
            doc.Save(path);
        }
    }
}
