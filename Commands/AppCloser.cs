using System;
using System.Windows.Input;

namespace CryptoApp.Commands
{
    internal class AppCloser : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            App.Current.MainWindow.Close();
        }
    }
}
