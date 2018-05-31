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
        private string localDeviceCode;  //generise se samo 
        private double localDevicePeriod; //mi unosimo
        private int localDeviceValue; //random se generise
        private int localDeviceLimit; //mi unosimo
        private string localDeviceType; //mi unosimo, radio button
        private bool localDeviceState; //u pocetku je ugasen, metodama ga palimo i gasimo
        private string localDeviceDestination; //mi unosimo, combobox
        private string localDeviceControllerName;
        

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

        public string LocalDeviceControllerName { get => localDeviceControllerName; set => localDeviceControllerName = value; }
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
            localDeviceControllerName = "";

    }

    public LocalDevice(double period, int limit, string type, string destination, string controllerName)
        {
            localDeviceCount++;
            localDeviceCode = "LD" + localDeviceCount.ToString();
            localDevicePeriod = period;
            localDeviceValue = 0;
            localDeviceLimit = limit;
            localDeviceState = false;
            localDeviceType = type;
            localDeviceDestination = destination;
            localDeviceControllerName = controllerName;

    }

    public void TurnOn()
        {
            if(this.LocalDeviceState)
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
