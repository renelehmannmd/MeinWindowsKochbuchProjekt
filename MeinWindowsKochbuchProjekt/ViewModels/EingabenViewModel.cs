using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MeinWindowsKochbuchProjekt.Datenmodell;
using MeinWindowsKochbuchProjekt.MyRelayCommand;

using System.Windows;

using Microsoft.EntityFrameworkCore;

namespace MeinWindowsKochbuchProjekt.ViewModels
{
    public class EingabenViewModel : ViewModelBase
    {
        private int selectedNumber;
        public int SelectedNumber
        {
            get => selectedNumber;
            set
            {
                selectedNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Komplette Liste der Lebensmittel
        /// </summary>
        private ObservableCollection<Lebensmittel> lebensmittelListeVM;
        public ObservableCollection<Lebensmittel> LebensmittelListeVM
        {
            get => lebensmittelListeVM;
            set
            {
                lebensmittelListeVM = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Selected Item vom Typ Lebensmittel für das Binding des DataGrid / SelectedItem
        /// </summary>
        private Lebensmittel firstSelectedItem;
        public Lebensmittel FirstSelectedItem
        {
            get => firstSelectedItem;
            set
            {
                firstSelectedItem = value;
                OnPropertyChanged();
                AendereSelectedNumber();

            }
        }

        private LebensmittelKategorie secondSelectedItem;
        public LebensmittelKategorie SecondSelectedItem
        {
            get => secondSelectedItem;
            set
            {
                secondSelectedItem = value;
                OnPropertyChanged();
                
            }
        }


        private ObservableCollection<LebensmittelKategorie> listeLebensmittelKategorien;
        public ObservableCollection<LebensmittelKategorie> ListeLebensmittelKategorien
        {
            get => listeLebensmittelKategorien;
            set
            {
                listeLebensmittelKategorien = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Konstruktor des Viemodels
        /// </summary>
        public EingabenViewModel() : base()
        {
            var db = new RezeptDataContext();
            var lm = db.Lebensmittels
                .Include(l => l.Naehrwerttabelle)
                .Include(lk => lk.LebensmittelKategorie)
                .OrderBy(l=> l.LebensmittelName)
                .ToList();
 
            LebensmittelListeVM = new ObservableCollection<Lebensmittel>(lm);
            ListeLebensmittelKategorien = new ObservableCollection<LebensmittelKategorie>(db.LebensmittelKategorien.OrderBy(l=>l.LeKaName).ToList());

            LoescheDatensatz = new RelayCommand(ExecuteLoescheDatensatz, CanExecuteLoescheDatensatz);
            BearbeiteDatensatz = new RelayCommand(ExecuteBearbeiteDatensatz, CanExecuteBearbeiteDatensatz);
            SelectedNumber = -1;
        }

        #region RelayCommand LoescheDatensatz
        public RelayCommand LoescheDatensatz { get; private set; }

        private void ExecuteLoescheDatensatz(object Parameter)
        {
            using (var db = new RezeptDataContext())
            {
                db.Lebensmittels.Remove(firstSelectedItem);
                db.SaveChanges();
                FirstSelectedItem = null;

                LebensmittelListeVM = new ObservableCollection<Lebensmittel>(
                    db.Lebensmittels
                    .Include(l => l.Naehrwerttabelle)
                    .OrderBy(l => l.LebensmittelName)
                    .ToList());


            }
        }

        private bool CanExecuteLoescheDatensatz(object Parameter)
        {
            return FirstSelectedItem != null;
        }

        #endregion


        #region RelayCommand BearbeiteDatensatz
        public RelayCommand BearbeiteDatensatz { get; set; }

        private void ExecuteBearbeiteDatensatz(object Parameter)
        {
            using (var db = new RezeptDataContext())
            {
                FirstSelectedItem.LebensmittelKategorie = SecondSelectedItem;
                db.Lebensmittels.Update(firstSelectedItem);
                db.SaveChanges();
                FirstSelectedItem = null;
                SecondSelectedItem = null;
                SelectedNumber = -1;

                LebensmittelListeVM = new ObservableCollection<Lebensmittel>(
                    db.Lebensmittels
                    .Include(l => l.Naehrwerttabelle)
                    .Include(lk => lk.LebensmittelKategorie)
                    .OrderBy(l => l.LebensmittelName)
                    .ToList());


            }
        }

        private bool CanExecuteBearbeiteDatensatz(object Parameter)
        {
            return FirstSelectedItem != null && SecondSelectedItem != null;
        }
        #endregion


        private void AendereSelectedNumber()
        {
            if(FirstSelectedItem != null)
                SelectedNumber = ListeLebensmittelKategorien.IndexOf(firstSelectedItem.LebensmittelKategorie);

            //MessageBox.Show(SelectedNumber.ToString());
        }

    }
}
