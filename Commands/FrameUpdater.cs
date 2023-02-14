using CryptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;

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
