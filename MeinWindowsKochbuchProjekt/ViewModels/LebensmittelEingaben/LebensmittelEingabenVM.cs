using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinWindowsKochbuchProjekt.ViewModels.LebensmittelEingaben
{
    public class LebensmittelEingabenVM : ViewModelBase
    {
        private string dateiName;
        public string DateiName
        {
            get => dateiName;
            set
            {
                dateiName = value;
                OnPropertyChanged();
            }
        }

        public LebensmittelEingabenVM()
        {

        }
    }
}
