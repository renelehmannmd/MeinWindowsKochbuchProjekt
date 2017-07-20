using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Controls.Ribbon;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MeinWindowsKochbuchProjekt.Datenmodell;
using MeinWindowsKochbuchProjekt.Extensions;

namespace MeinWindowsKochbuchProjekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new RezeptDataContext())
            {
                db.Database.Migrate();
                if (db.Lebensmittels.ToList().Count == 0)
                {
                    ImportLebensmittel.LegeStandardLebensmittelBildFest();
                    ImportLebensmittel.LegeLebensmittelKategorienAn();
                    ImportLebensmittel.ImportiereLebensmittel();
                    ImportLebensmittel.LegeRezeptKategorienAn();
                }
            }

            
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MenuItem_LebensmittelBearbeiten_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("Views\\LebensmittelBearbeitung\\eingaben.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MenuItem_LebensmittelAnzeigen_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("Views\\lebensmittelanzeige\\lebensmittelanzeige.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MenuItem_LebensmittelHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Uri("Views\\LebensmittelEingaben\\LebensmittelEingaben.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
