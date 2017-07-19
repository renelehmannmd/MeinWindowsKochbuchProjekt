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

using MeinWindowsKochbuchProjekt.ViewModels.LebensmittelEingaben;

namespace MeinWindowsKochbuchProjekt.Views.LebensmittelEingaben
{
    /// <summary>
    /// Interaktionslogik für LebensmittelEingaben.xaml
    /// </summary>
    public partial class LebensmittelEingaben : Page
    {
        public LebensmittelEingaben()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myData = pagenamen.DataContext as LebensmittelEingabenVM;
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Bilddateien (*.png), | *.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            if(ofd.ShowDialog() == true)
            {
                myData.DateiName = ofd.FileName;  
            }

        }
    }
}
