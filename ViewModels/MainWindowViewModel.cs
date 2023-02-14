﻿using CryptoApp.Commands;
using CryptoApp.Interfaces;
using CryptoApp.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CryptoApp.Models;

namespace CryptoApp.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private HomePage _homePage;
        private MarketPage _marketPage;
        private ConverterPage _converterPage;
        private CoinPage _coinPage;

        public MainWindowViewModel()
        {
            _homePage = new HomePage();
            _marketPage = new MarketPage();   
            _converterPage = new ConverterPage();
            _coinPage = new CoinPage();
            SelectedPage = _homePage;
        }


        private IPage _selectedPage;
        public IPage SelectedPage 
        { 
            get { return _selectedPage; }
            set { 
                _selectedPage = value; 
                OnPropertyChanged("SelectedPage");
            } 
        }

        private ICommand _frameUpdater;
        public ICommand FrameUpdate
        {
            get {
                if (_frameUpdater == null)
                    _frameUpdater = new FrameUpdater(this);
                return _frameUpdater;
            }
            set { _frameUpdater = value; }
        }

        private ICommand _appCloser;
        public ICommand CloseApp
        {
            get {
                if (_appCloser == null)
                    _appCloser = new AppCloser();
                return _appCloser;
            }
            set { _appCloser = value; }
        }


        public void SetSelectedPage(string pageName)
        {
            switch (pageName)
            {
                case "Home":
                    SelectedPage = _homePage; break;
                case "Market":
                    SelectedPage = _marketPage; break;
                case "Converter":
                    SelectedPage = _converterPage; break;
                default:
                    return;
            }
        }

        public void SetCoinPage(Coin actualCoin)
        {
            SelectedPage = _coinPage;
            CoinPageViewModel coinPageVM = (CoinPageViewModel)_coinPage.DataContext;
            coinPageVM.ActualCoin = actualCoin;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
