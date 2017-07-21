using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MeinWindowsKochbuchProjekt.Datenmodell;
using System.Collections.ObjectModel;

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

        private Bild bildVM;

        public Bild BildVM
        {
            get => bildVM;
            set
            {
                bildVM = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LebensmittelKategorie> kategorieListeVM;
        public ObservableCollection<LebensmittelKategorie> KategorieListeVM
        {
            get => kategorieListeVM;
            set
            {
                kategorieListeVM = value;
                OnPropertyChanged();
            }
        }

        public LebensmittelEingabenVM()
        {
            List<LebensmittelKategorie> lk = new List<LebensmittelKategorie>();
            using (RezeptDataContext db = new RezeptDataContext())
            {
                lk = db.LebensmittelKategorien
                    .OrderBy(l => l.LeKaName)
                    .ToList();
            }
                KategorieListeVM = new ObservableCollection<LebensmittelKategorie>(lk);
        }
    }
}
