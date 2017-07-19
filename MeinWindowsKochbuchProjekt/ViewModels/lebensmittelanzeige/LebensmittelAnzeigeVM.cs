﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

using MeinWindowsKochbuchProjekt.ViewModels;
using MeinWindowsKochbuchProjekt.Datenmodell;

namespace MeinWindowsKochbuchProjekt.ViewModels.lebensmittelanzeige
{
    public class LebensmittelAnzeigeVM : ViewModelBase
    {
        private ObservableCollection<Lebensmittel> lebensmittelListe;
        public ObservableCollection<Lebensmittel> LebensmittelListe
        {
            get => lebensmittelListe;
            set
            {
                lebensmittelListe = value;
                OnPropertyChanged();
            }
        }

        private string suchWort;
        public string SuchWort
        {
            get => suchWort;
            set
            {
                suchWort = value;
                OnPropertyChanged();
                ListeFuellen(value);
            }
        }

        private Lebensmittel firstSelectedItem;
        public Lebensmittel FirstSelectedItem
        {
            get => firstSelectedItem;
            set
            {
                firstSelectedItem = value;
                OnPropertyChanged();
            }
        }

        public LebensmittelAnzeigeVM()
        {
            LebensmittelListe = new ObservableCollection<Lebensmittel>(LebensmittelListeErzeugen(String.Empty));
        }

        private void ListeFuellen(string searchstring = null)
        {
            LebensmittelListe= new ObservableCollection<Lebensmittel>(LebensmittelListeErzeugen(searchstring));
        }

        private List<Lebensmittel> LebensmittelListeErzeugen(string searchstring)
        {
            if (String.IsNullOrEmpty(searchstring))
                searchstring = "";

            using (var db = new RezeptDataContext())
            {
                return db.Lebensmittels
                    .Where(k => k.LebensmittelName.ToLower().Contains(searchstring.ToLower()))
                    .Include(nw => nw.Naehrwerttabelle)
                    .Include(k => k.LebensmittelKategorie)
                    .OrderBy(l => l.LebensmittelName)
                    .ToList();
                    
            }
            
        }
        
    }
}
