using LocalController.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SharedClass
    {
        public static ObservableCollection<LocalController.Classes.LocalController> LocalControllerList { get; set; }
    }
}
