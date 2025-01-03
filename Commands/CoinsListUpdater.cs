﻿using System;
using System.Windows.Input;
using CryptoApp.Interfaces;


namespace CryptoApp.Commands
{
    internal class CoinsListUpdater : ICommand
    {
        private ICoinsPageUpdate _coinsPageVM;

        public CoinsListUpdater(ICoinsPageUpdate coinsPageVM)
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
