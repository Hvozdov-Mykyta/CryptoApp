using CryptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
