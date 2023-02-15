using System;
using System.Windows.Input;
using CryptoApp.ViewModels;


namespace CryptoApp.Commands
{
    internal class CoinPageUpdater : ICommand
    {
        private CoinPageViewModel _coinPageVM;

        public CoinPageUpdater(CoinPageViewModel coinPageVM)
        {
            _coinPageVM = coinPageVM;
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
            _coinPageVM.UpdateActualCoin();
        }
    }
}
