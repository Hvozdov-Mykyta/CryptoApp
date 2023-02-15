using System;
using System.Windows.Input;
using CryptoApp.ViewModels;


namespace CryptoApp.Commands
{
    internal class FrameUpdater : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public FrameUpdater(MainWindowViewModel mainWindowVM)
        {
            _mainWindowViewModel = mainWindowVM;
        }


        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(parameter as string);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.SetSelectedPage(parameter as string);
        }
    }
}
