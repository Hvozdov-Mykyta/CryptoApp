using System;
using System.Windows.Input;
using CryptoApp.Interfaces;
using CryptoApp.Models;

namespace CryptoApp.Commands
{
    internal class CoinPageOpener : ICommand
    {
        private ICoinsPage _coinsPageVM;

        public CoinPageOpener(ICoinsPage coinsPageVM)
        {
            _coinsPageVM = coinsPageVM;
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
            _coinsPageVM.ViewSelectedCoin();
        }
    }
}
