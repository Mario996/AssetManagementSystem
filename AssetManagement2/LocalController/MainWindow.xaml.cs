using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;

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
        XmlWriter xmlWriter;
        XmlWriter xmlWriter1;

        public MainWindow()
        {
            InitializeComponent();
            LocalDeviceList = new ObservableCollection<LocalDevice>();
            LocalControllerList = new ObservableCollection<Classes.LocalController>();
            localControllersIds = new ObservableCollection<string>();
            DataContext = this;
            ChangeValue();
            SendToAMS();
            DeleteBuffer();
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
                                    
                                    if(ld.LocalDeviceDestination.Equals("Local controller"))
                                    {
                                        SaveToLC(ld.LocalDeviceCode, $@"../Debug/Devices/{ld.LocalDeviceControllerCode}.xml", ld.LocalDeviceValue);
                                    }
                                    else
                                    {
                                        SaveToAMS(ld.LocalDeviceCode, $"../../../AMS/bin/Debug/Controllers/ams.xml", ld.LocalDeviceValue, ld.LocalDeviceControllerCode);
                                    }
                                    
                                }
                                else
                                {
                                    ld.LocalDeviceValue = rand.Next(210, 240);
                                    ld.LocalDeviceValues.Add(ld.LocalDeviceValue);
                                    if(ld.LocalDeviceDestination.Equals("Local controller"))
                                    {
                                        SaveToLC(ld.LocalDeviceCode, $@"../Debug/Devices/{ld.LocalDeviceControllerCode}.xml", ld.LocalDeviceValue);
                                    }
                                    else
                                    {
                                        SaveToAMS(ld.LocalDeviceCode, $"../../../AMS/bin/Debug/Controllers/ams.xml", ld.LocalDeviceValue, ld.LocalDeviceControllerCode);
                                    }
                                    
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

        private void DeleteBuffer()
        {
            string path = $@"./Devices";
            string trazenoImeFilea = "";
            var thread1 = new Thread(() =>
            {
                while (true)
                {
                    foreach (LocalController.Classes.LocalController lc in LocalControllerList)
                    {
                        if (Directory.EnumerateFileSystemEntries(path).Any())
                        {
                            if (lc.LocalControllerState)
                            {
                                string[] files = Directory.GetFiles(path);
                                foreach (string filename in files)
                                {
                                    //./Devices\\LC1.xml
                                    var temp = filename.Substring(10, lc.LocalControllerCode.Length);
                                    if (lc.LocalControllerCode.Equals(temp))
                                    {
                                        trazenoImeFilea = temp;
                                        break;
                                    }
                                }

                                File.Delete(path + "/" + trazenoImeFilea + ".xml");
                            }
                        }

                    }
                    Thread.Sleep(6000);

                }
            });
            thread1.IsBackground = true;
            thread1.Start();
        }

        public void SendToAMS()
        {
            var thread1 = new Thread(() =>
            {
                while (true)
                {
                    string path = $@"./Devices"; 
                    string[] files = Directory.GetFiles(path);
                  
                    XmlWriterSettings xmlWriterSettings1 = new XmlWriterSettings();
                    xmlWriterSettings1.Indent = true;
                    xmlWriterSettings1.NewLineOnAttributes = true;

                    if (!File.Exists($"../../../AMS/bin/Debug/Controllers/ams.xml"))
                    {

                        xmlWriter1 = XmlWriter.Create("../../../AMS/bin/Debug/Controllers/ams.xml", xmlWriterSettings1);

                        using (xmlWriter1)
                        {
                            xmlWriter1.WriteStartDocument();
                            xmlWriter1.WriteStartElement("controllers");
                            
                            xmlWriter1.WriteEndElement();
                            xmlWriter1.WriteEndDocument();
                            xmlWriter1.Flush();
                            xmlWriter1.Close();
                        }
                    }
                    else
                    {
                        XDocument doc = XDocument.Load("../../../AMS/bin/Debug/Controllers/ams.xml");

                        foreach(string f in files)
                        {
                            var controllerFile = XDocument.Load(f);
                            XElement item = XElement.Load(f);
                            XElement element = (from el in item.Elements() where (string)el.Attribute("code") == System.IO.Path.GetFileNameWithoutExtension(f) select el).FirstOrDefault();

                            if(element == null)
                            {
                                XElement controller = new XElement("controller");
                                controller.Add(new XAttribute("code", System.IO.Path.GetFileNameWithoutExtension(f)));
                                controller.Add(new XAttribute("time", DateTime.Now.ToString()));
                                controller.Add(controllerFile.Root.Elements());
                                doc.Element("controllers").Add(controller);
                            }
                            else
                            {
                                element.Add(controllerFile.Root.Elements());
                            }
                        }

                        doc.Save("../../../AMS/bin/Debug/Controllers/ams.xml");

                    }

                   Thread.Sleep(5000);
                }
            });
            thread1.IsBackground = true;
            thread1.Start();
        }

        public void SaveToLC(string code, string file, int value)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;

            if (!File.Exists(file))
            {
                xmlWriter = XmlWriter.Create(file, xmlWriterSettings);

                using (xmlWriter)
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("devices");
                    xmlWriter.WriteStartElement("device");
                    xmlWriter.WriteAttributeString("code", code);

                    //xmlWriter.WriteStartElement("time");
                    //xmlWriter.WriteRaw(DateTime.Now.ToString());
                    //xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("value");
                    xmlWriter.WriteAttributeString("time", DateTime.Now.ToString());
                    xmlWriter.WriteRaw(value.ToString());

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement(); //zatvoren device
                    xmlWriter.WriteEndElement(); //zatvoren devices
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();

                }
            }
            else
            {
                
                XElement doc1 = XElement.Load(file);
                XElement element = (from el in doc1.Elements() where (string)el.Attribute("code").Value == code select el).FirstOrDefault();
               
               if (element == null)
               {
                    XDocument doc = XDocument.Load(file);
                    XElement root = new XElement("device");
                    root.Add(new XAttribute("code", code));
                    XElement val = new XElement("value", value.ToString());
                    val.Add(new XAttribute("time", DateTime.Now.ToString()));
                    root.Add(val);
                    // root.Add(new XElement("time", DateTime.Now.ToString()));
                   // root.Add(new XElement("value", value.ToString()),new XAttribute("time", DateTime.Now.ToString()));
                    //root.Add(new XAttribute("time", DateTime.Now.ToString()));
                    doc.Element("devices").Add(root);
                    doc.Save(file);

               }
               else
               {
                    XElement val = new XElement("value", value.ToString());
                    val.Add(new XAttribute("time", DateTime.Now.ToString()));
                    element.Add(val);
                    // element.Add(new XElement("time", DateTime.Now.ToString()));
                    // element.Add(new XElement("value", value.ToString()), new XAttribute("time", DateTime.Now.ToString()));
                    // element.Add(new XAttribute("time", DateTime.Now.ToString()));
                    doc1.Save(file);
               }
            }
        }

        public void SaveToAMS(string code, string file, int value, string controllerCode)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;

            if (!File.Exists(file))
            {
                xmlWriter = XmlWriter.Create(file, xmlWriterSettings);

                using (xmlWriter)
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("device");
                    xmlWriter.WriteAttributeString("code", code);

                    //xmlWriter.WriteStartElement("time");
                    //xmlWriter.WriteRaw(DateTime.Now.ToString());
                    //xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("value");
                    xmlWriter.WriteAttributeString("time", DateTime.Now.ToString());
                    xmlWriter.WriteRaw(value.ToString());

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement(); //zatvoren device
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();

                }
            }
            else
            {

                XElement doc1 = XElement.Load(file);
                XElement element = (from el in doc1.Elements() where (string)el.Attribute("code").Value == code select el).FirstOrDefault();

                if (element == null)
                {
                    XDocument doc = XDocument.Load(file);
                    XElement root = new XElement("controller");
                    XElement device = new XElement("device");
                    device.Add(new XAttribute("code", code));
                    root.Add(new XAttribute("time", DateTime.Now.ToString()));
                    root.Add(new XAttribute("code", controllerCode));
                    root.Add(device);
                    XElement val = new XElement("value", value.ToString());
                    val.Add(new XAttribute("time", DateTime.Now.ToString()));
                    root.Add(val);
                    //root.Add(new XElement("time", DateTime.Now.ToString()));
                    //root.Add(new XElement("value", value.ToString()));
                    doc.Element("controllers").Add(root);
                    //doc.Add(root);
                    doc.Save(file);

                }
                else
                {
                    XElement val = new XElement("value", value.ToString());
                    val.Add(new XAttribute("time", DateTime.Now.ToString()));
                    element.Add(val);
                    //element.Add(new XElement("time", DateTime.Now.ToString()));
                    //element.Add(new XElement("value", value.ToString()));
                    doc1.Save(file);
                }
            }
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

