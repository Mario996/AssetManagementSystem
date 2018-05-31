using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LocalController.Classes
{
    public class LocalController : INotifyPropertyChanged
    {
        private double localControllerPeriod; // mi unospimo
        private string localControllerCode; //samo se generise
        private bool localControllerState;
        private static Dictionary<LocalDevice, List<int>> localControllerValuesHistory;
        private static int localControllerCount = 0;
        private List<LocalDevice> deviceList;

        public event PropertyChangedEventHandler PropertyChanged;

        public double LocalControllerPeriod
        {
            get
            {
                return localControllerPeriod;
            }

            set
            {
                if (localControllerPeriod != value)
                {
                    localControllerPeriod = value;
                    RaisePropertyChanged("LocalControllerPeriod");
                }
            }
        }

        public string LocalControllerCode
        {
            get
            {
                return localControllerCode;
            }

            set
            {
                if (localControllerCode != value)
                {
                    localControllerCode = value;
                    RaisePropertyChanged("LocalControllerCode");
                }
            }
        }

        public bool LocalControllerState
        {
            get
            {
                return localControllerState;
            }

            set
            {
                if (localControllerState != value)
                {
                    localControllerState = value;
                    RaisePropertyChanged("LocalControllerState");
                }
            }
        }

        public List<LocalDevice> DeviceList
        {
            get
            {
                return deviceList;
            }

            set
            {
                if (deviceList != value)
                {
                    deviceList = value;
                    RaisePropertyChanged("DeviceList");
                }
            }
        }

        public static Dictionary<LocalDevice, List<int>> LocalControllerValuesHistory { get => localControllerValuesHistory; set => localControllerValuesHistory = value; }

        public LocalController()
        {
            localControllerCode = "";
            localControllerPeriod = -1;
            localControllerState = false;
            LocalControllerValuesHistory = new Dictionary<LocalDevice, List<int>>();
            deviceList = new List<LocalDevice>();
        }

        public LocalController(double period, string controllerCode)
        {
            localControllerCount++;
            localControllerCode = controllerCode;
            localControllerPeriod = period;
            localControllerState = false;
            LocalControllerValuesHistory = new Dictionary<LocalDevice, List<int>>();
            deviceList = new List<LocalDevice>();
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void TurnOn()
        {
            if (this.LocalControllerState)
            {
                MessageBox.Show("You can't turn on this local controller, it is already working!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.LocalControllerState = true;
            }
        }

        public void TurnOff()
        {
            if (this.LocalControllerState)
            {
                this.LocalControllerState = false;
            }
            else
            {
                MessageBox.Show("You can't turn off this local controller, it's not working at the moment!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
