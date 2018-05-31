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
        private double localControllerPeriod; 
        private string localControllerCode; 
        private bool localControllerState;
        private List<LocalDevice> localControllerDevices;
        private static int localControllerCount = 0;


        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

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

        public List<LocalDevice> LocalControllerDevices
        {
            get
            {
                return localControllerDevices;
            }

            set
            {
                if (localControllerDevices != value)
                {
                    localControllerDevices = value;
                    RaisePropertyChanged("LocalControllerDevices");
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

        #endregion

        public LocalController()
        {
            localControllerCode = "";
            localControllerPeriod = -1;
            localControllerState = false;
            localControllerDevices = new List<LocalDevice>();
        }

        public LocalController(double period)
        {
            localControllerCount++;
            localControllerCode = "LC" + localControllerCount;
            localControllerPeriod = period;
            localControllerState = false;
            localControllerDevices = new List<LocalDevice>();

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
