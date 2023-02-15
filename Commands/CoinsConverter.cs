using System;
using System.Windows.Input;
using CryptoApp.ViewModels;


namespace CryptoApp.Commands
{
    internal class CoinsConverter : ICommand
    {
        private ConverterPageViewModel _converterPageVM;

        public CoinsConverter(ConverterPageViewModel converterPageVM)
        {
            _converterPageVM = converterPageVM;
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
            _converterPageVM.ConvertCoins();
        }
    }
}
