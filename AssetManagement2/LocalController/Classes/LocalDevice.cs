using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LocalController.Classes
{
    public class LocalDevice : INotifyPropertyChanged
    {
        private string localDeviceCode;   
        private double localDevicePeriod; 
        private int localDeviceValue; 
        private int localDeviceLimit; 
        private string localDeviceType; 
        private bool localDeviceState; 
        private string localDeviceDestination; 
        private List<int> localDeviceValues;
        private string localDeviceControllerCode;


        private static int localDeviceCount = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public string LocalDeviceCode
        {
            get
            {
                return localDeviceCode;
            }

            set
            {
                if (localDeviceCode != value)
                {
                    localDeviceCode = value;
                    RaisePropertyChanged("LocalDeviceCode");
                }
            }
        }

        public string LocalDeviceControllerCode
        {
            get
            {
                return localDeviceControllerCode;
            }

            set
            {
                if (localDeviceControllerCode != value)
                {
                    localDeviceControllerCode = value;
                    RaisePropertyChanged("LocalDeviceCodeControllerCode");
                }
            }
        }

        public double LocalDevicePeriod
        {
            get
            {
                return localDevicePeriod;
            }

            set
            {
                if (localDevicePeriod != value)
                {
                    localDevicePeriod = value;
                    RaisePropertyChanged("LocalDevicePeriod");
                }
            }
        }

        public int LocalDeviceValue
        {
            get
            {
                return localDeviceValue;
            }

            set
            {
                if (localDeviceValue != value)
                {
                    localDeviceValue = value;
                    RaisePropertyChanged("LocalDeviceValue");
                }
            }
        }

        public int LocalDeviceLimit
        {
            get
            {
                return localDeviceLimit;
            }

            set
            {
                if (localDeviceLimit != value)
                {
                    localDeviceLimit = value;
                    RaisePropertyChanged("LocalDeviceLimit");
                }
            }
        }

        public bool LocalDeviceState
        {
            get
            {
                return localDeviceState;
            }

            set
            {
                if (localDeviceState != value)
                {
                    localDeviceState = value;
                    RaisePropertyChanged("LocalDeviceState");
                }
            }
        }

        public string LocalDeviceType
        {
            get
            {
                return localDeviceType;
            }

            set
            {
                if (localDeviceType != value)
                {
                    localDeviceType = value;
                    RaisePropertyChanged("LocalDeviceType");
                }
            }
        }

        public string LocalDeviceDestination
        {
            get
            {
                return localDeviceDestination;
            }

            set
            {
                if (localDeviceDestination != value)
                {
                    localDeviceDestination = value;
                    RaisePropertyChanged("LocalDeviceDestination");
                }
            }
        }

        public List<int> LocalDeviceValues
        {
            get
            {
                return localDeviceValues;
                ;
            }

            set
            {
                if (localDeviceValues != value)
                {
                    localDeviceValues = value;
                    RaisePropertyChanged("LocalDeviceValues");
                }
            }
        }
        #endregion

        public LocalDevice()
        {
            localDeviceCode = "";
            localDevicePeriod = -1;
            localDeviceValue = -1;
            localDeviceLimit = -1;
            localDeviceState = false;
            localDeviceType = "";
            localDeviceDestination = "";
            localDeviceValues = new List<int>();
            localDeviceControllerCode = "";
        }

        public LocalDevice(string code, double period, int limit, string type, string destination,string lcCode)
        {
            localDeviceCount++;
            localDeviceCode = code;
            localDevicePeriod = period;
            localDeviceValue = 0;
            localDeviceLimit = limit;
            localDeviceState = false;
            localDeviceType = type;
            localDeviceDestination = destination;
            localDeviceValues = new List<int>();
            localDeviceControllerCode = lcCode;
        }

        public void TurnOn()
        {
            if (this.LocalDeviceState)
            {
                MessageBox.Show("You can't turn on this local device, it is already working!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.LocalDeviceState = true;
            }
        }

        public void TurnOff()
        {
            if (this.LocalDeviceState)
            {
                this.LocalDeviceState = false;
            }
            else
            {
                MessageBox.Show("You can't turn off this local device, it's not working at the moment!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
