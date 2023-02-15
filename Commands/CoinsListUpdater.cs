using System;
using System.Windows.Input;
using CryptoApp.Interfaces;


namespace CryptoApp.Commands
{
    internal class CoinsListUpdater : ICommand
    {
        private ICoinsPage _coinsPageVM;

        public CoinsListUpdater(ICoinsPage coinsPageVM)
        {
            _coinsPageVM = coinsPageVM;
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
            _coinsPageVM.UpdateCoinsList();
        }
    }
}
