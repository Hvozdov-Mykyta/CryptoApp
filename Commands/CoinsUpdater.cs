using CryptoApp.ViewModels;
using System;
using System.Windows.Input;

namespace CryptoApp.Commands
{
    internal class CoinsUpdater : ICommand
    {
        private HomePageViewModel homePageVM;

        public CoinsUpdater(HomePageViewModel homePageVM)
        {
            this.homePageVM = homePageVM;
        }

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
            homePageVM.UpdateCoinsList();
        }
    }
}
