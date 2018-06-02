using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private static List<string> ListaRadniSati { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            ListaVrednosti = new List<string>();
            ListValue = new List<int>();
            ListTime = new List<DateTime>();
            ListaRadniSati = new List<string>();

        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {

            //02-Jun-18 15:40:53
            DateTime dateTimeStart = DateTime.ParseExact(textBoxStart.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);
            DateTime dateTimeEnd = DateTime.ParseExact(textBoxEnd.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);

            string path = "../../../AMS/bin/Debug/Controllers/ams.xml";

            XDocument doc = XDocument.Load(path);
            IEnumerable<XElement> elements = (from el in doc.Descendants("device") where (string)el.Attribute("code").Value == textBoxLD.Text.ToString() select el); //ovde su svi device
    

            IEnumerable<XElement> values = (from el in elements.Descendants("value") select el); //ovde su sve vrednosti

            foreach(XElement xe in values)
            {
                if (DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) >= dateTimeStart && DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) <= dateTimeEnd)
                ListaVrednosti.Add("Value: " + xe.Value +" time: " + xe.FirstAttribute.Value); //ovde ubacujemo one vrednosti koje upadaju u vreme izmedju
            }

            textBoxReport.Text = String.Join(Environment.NewLine ,ListaVrednosti);
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

           if(data1[0].Value == 0 || data1[0].Value == 1)
           {
                MessageBox.Show("This graph works only for analog local devices!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                ListValue.Clear();
                ListTime.Clear();
                doc.Save(path);
           }
           else
           {
                series.ItemsSource = data1;
                ListValue.Clear();
                ListTime.Clear();
                doc.Save(path);
            }
         
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            bool digitalanJe = false;
            //02-Jun-18 15:40:53
            DateTime dateTimeStart = DateTime.ParseExact(textBoxStartRadniSati.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);
            DateTime dateTimeEnd = DateTime.ParseExact(textBoxEndRadniSati.Text, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);

            string path = "../../../AMS/bin/Debug/Controllers/ams.xml";

            XDocument doc = XDocument.Load(path);
            IEnumerable<XElement> elements = (from el in doc.Descendants("device") where (string)el.Attribute("code").Value == textBoxLDRadniSati.Text.ToString() select el); //ovde su svi device


            IEnumerable<XElement> values = (from el in elements.Descendants("value") select el); //ovde su sve vrednosti

            foreach (XElement xe in values)
            {
                if (DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) >= dateTimeStart && DateTime.ParseExact(xe.FirstAttribute.Value, "dd-MMM-yy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None) <= dateTimeEnd)
                {
                    ListaRadniSati.Add("Value: " + xe.Value + " time: " + xe.FirstAttribute.Value); //ovde ubacujemo one vrednosti koje upadaju u vreme izmedju
                    if(xe.Value.Equals("0") || xe.Value.Equals("1"))
                    {
                        digitalanJe = true;
                    }
                }

            }

            if(digitalanJe)
            {
                MessageBox.Show("This information is available only for analog local devices!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                ListaRadniSati.Clear();
                textBoxReportRadniSati.Text = "";
            }
            else
            {
                textBoxReportRadniSati.Text = "Local device " + textBoxLDRadniSati.Text + " je imao " + (Decimal.Divide(ListaRadniSati.Count, 10)).ToString() + " radna sata u izabranom periodu.";
                ListaRadniSati.Clear();
            }
            
            doc.Save(path);
        }

        private void Show4_Click(object sender, RoutedEventArgs e)
        {

            int limit = Int32.Parse(textBoxLimit.Text);
            string imeLC = textBoxNameLC.Text;
            string text = String.Empty;

            if (cbAMS.IsChecked == true && cbLC.IsChecked == true)
            {
                MessageBox.Show("You can't check both fields(AMS and Local controller).", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cbAMS.IsChecked == false && cbLC.IsChecked == false)
            {
                MessageBox.Show("You must check one field(AMS or Local controller).", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (BrPromjena.IsChecked == true && BrRadnihSati.IsChecked == true)
            {
                MessageBox.Show("You can't check both fields.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (BrPromjena.IsChecked == false && BrRadnihSati.IsChecked == false)
            {
                MessageBox.Show("You must check one field.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (cbAMS.IsChecked == true)
            {
                string path = "../../../AMS/bin/Debug/Controllers/ams.xml";
                XDocument doc = XDocument.Load(path);

                IEnumerable<XElement> elements = (from el in doc.Descendants("device") select el);

                Dictionary<string, List<string>> vrijednosti = new Dictionary<string, List<string>>();

                foreach (XElement xe in elements)
                {
                    IEnumerable<XElement> values = (from el in xe.Descendants("value") select el);

                    foreach (XElement val in values)
                    {
                        if (vrijednosti.ContainsKey(xe.Attribute("code").Value))
                        {
                            vrijednosti[xe.Attribute("code").Value].Add(xe.Value);
                        }
                        else
                        {
                            vrijednosti.Add(xe.Attribute("code").Value, new List<string>() { xe.Value });
                        }
                    }
                }

                if (BrRadnihSati.IsChecked == true)
                {
                    foreach (KeyValuePair<string, List<string>> kv in vrijednosti)
                    {
                        if (kv.Value.ElementAt(0) != "0" && kv.Value.ElementAt(0) != "1")
                        {
                            if (Decimal.Divide(kv.Value.Count, 10) > limit)
                            {
                                text = "Local device: " + kv.Key + " Broj radnih sati: " + Decimal.Divide(kv.Value.Count, 10) + "\n";
                            }
                        }
                    }

                    textBox4.Text = text;
                }
                else if (BrPromjena.IsChecked == true)
                {
                    foreach (KeyValuePair<string, List<string>> kv in vrijednosti)
                    {
                        if (kv.Value[0].Equals("0") || kv.Value[0].Equals("1"))
                        {
                            if (kv.Value.Count > limit)
                            {
                                text = "Local device: " + kv.Key + " Broj promjena: " + kv.Value.Count + "\n";
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    textBox4.Text = text;
                }
            }
            else if (cbLC.IsChecked == true)
            {

                string path = "../../../AMS/bin/Debug/Controllers/ams.xml";
                XDocument doc = XDocument.Load(path);

                IEnumerable<XElement> elements = (from el in doc.Descendants("controller") where (string)el.Attribute("code").Value == imeLC select el);

                Dictionary<string, List<string>> vrijednosti = new Dictionary<string, List<string>>();

                foreach (XElement xe in elements)
                {
                    IEnumerable<XElement> devices = xe.Descendants("device");

                    foreach (XElement xed in devices)
                    {
                        IEnumerable<XElement> values = xed.Descendants("value");

                        foreach (XElement v in values)
                        {
                            if (vrijednosti.ContainsKey(xed.Attribute("code").Value))
                            {
                                vrijednosti[xed.Attribute("code").Value].Add(xed.Value);
                            }
                            else
                            {
                                vrijednosti.Add(xed.Attribute("code").Value, new List<string>() { xed.Value });
                            }
                        }
                    }
                }

                if (BrRadnihSati.IsChecked == true)
                {
                    foreach (KeyValuePair<string, List<string>> kv in vrijednosti)
                    {
                        if (kv.Value.ElementAt(0) != "0" && kv.Value.ElementAt(0) != "1")
                        {
                            if (Decimal.Divide(kv.Value.Count, 10) > limit)
                            {
                                text = "Local device: " + kv.Key + " Broj radnih sati: " + Decimal.Divide(kv.Value.Count, 10) + "\n";
                            }
                        }
                    }

                    textBox4.Text = text;
                }
                else if (BrPromjena.IsChecked == true)
                {
                    foreach (KeyValuePair<string, List<string>> kv in vrijednosti)
                    {
                        if (kv.Value[0].Equals("0") || kv.Value[0].Equals("1"))
                        {
                            if (kv.Value.Count > limit)
                            {
                                text = "Local device: " + kv.Key + " Broj promjena: " + kv.Value.Count + "\n";
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    textBox4.Text = text;
                }
            }
        }
    }
}
