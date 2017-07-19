using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MeinWindowsKochbuchProjekt.MyRelayCommand;

namespace MeinWindowsKochbuchProjekt.ViewModels
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            CloseCommand = new RelayCommand(ExecuteCloseCommand);
            MaximierenCommand = new RelayCommand(ExecuteMaximierenCommand);
            MinimierenCommand = new RelayCommand(ExecuteMinimierenCommand);
        }

        public RelayCommand CloseCommand { get; private set; }

        private void ExecuteCloseCommand(object parameter)
        {
            (parameter as MainWindow).Close();
        }

        public RelayCommand MaximierenCommand { get; private set; }

        private void ExecuteMaximierenCommand(object parameter)
        {
            
            if((parameter as MainWindow).WindowState == System.Windows.WindowState.Maximized)
            {
                (parameter as MainWindow).WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                (parameter as MainWindow).WindowState = System.Windows.WindowState.Maximized;
            }
        }

        public RelayCommand MinimierenCommand { get; private set; }

        private void ExecuteMinimierenCommand(object parameter)
        {
            (parameter as MainWindow).WindowState = System.Windows.WindowState.Minimized;
        }



    }
}
