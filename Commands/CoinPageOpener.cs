using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoApp.Models;
using CryptoApp.ViewModels;

namespace CryptoApp.Commands
{
    internal class CoinPageOpener : ICommand
    {
        private HomePageViewModel _homePageViewModel;

        public CoinPageOpener(HomePageViewModel homePageViewModel)
        {
            _homePageViewModel = homePageViewModel;
        }


        public bool CanExecute(object parameter)
        {
            return (parameter as Coin) != null;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _homePageViewModel.ViewSelectedCoin();
        }
    }
}
