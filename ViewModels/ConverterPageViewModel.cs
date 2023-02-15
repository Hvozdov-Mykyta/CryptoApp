using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using System.Windows;
using System;
using CryptoApp.Commands;
using CryptoApp.Interfaces;
using CryptoApp.Models;
using Newtonsoft.Json;

namespace CryptoApp.ViewModels
{
    internal class ConverterPageViewModel : INotifyPropertyChanged, ICoinsPageUpdate
    {
        private HttpRequests _httpRequests;

        public ConverterPageViewModel() 
        {
            _httpRequests = new HttpRequests();
            UpdateCoinsList();
        }



        private List<Coin> _coins;
        public List<Coin> Coins {
            get { return _coins; }
            set {
                _coins = value;
                OnPropertyChanged("Coins");
            }
        }

        private Coin _firstCoin;
        public Coin FirstCoin {
            get { return _firstCoin; }
            set { 
                _firstCoin= value;
                OnPropertyChanged("FirstCoin");
            }
        }

        private Coin _secondCoin;
        public Coin SecondCoin
        {
            get { return _secondCoin; }
            set
            {
                _secondCoin = value;
                OnPropertyChanged("SecondCoin");
            }
        }

        private string _firstCoinCount;
        public string FirstCoinCount
        {
            get { return _firstCoinCount; }
            set { 
                _firstCoinCount = value;
                OnPropertyChanged("FirstCoinCount");
            }
        }

        private string _secondCoinCount;
        public string SecondCoinCount
        {
            get { return _secondCoinCount; }
            set { 
                _secondCoinCount = value;
                OnPropertyChanged("SecondCoinCount");
            }
        }



        private ICommand _coinsListUpdater;
        public ICommand CoinsListUpdater {
            get {
                if (_coinsListUpdater == null)
                    _coinsListUpdater = new CoinsListUpdater(this);
                return _coinsListUpdater;
            }
            set { _coinsListUpdater = value; }
        }

        private ICommand _coinsConverter;
        public ICommand CoinsConverter {
            get {
                if(_coinsConverter == null)
                    _coinsConverter = new CoinsConverter(this);
                return _coinsConverter;
            }
            set { _coinsConverter = value; }
        }



        public async void UpdateCoinsList()
        {
            string json = await _httpRequests.GetAllAssets();
            Coins = JsonConvert.DeserializeObject<IntermediateCoinsList>(json).data;
        }

        public void ConvertCoins()
        {
            if(FirstCoin != null && SecondCoin != null)
            {
                double firstCoinCount = 0;
                try
                {
                    firstCoinCount = double.Parse(FirstCoinCount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (firstCoinCount < 0)
                {
                    MessageBox.Show("Coins count cant be less than 0");
                    return;
                }
                double firstCoinPrice = double.Parse(FirstCoin.priceUsd.Replace(',', '.'), CultureInfo.InvariantCulture);
                double SecondCoinPrice = double.Parse(SecondCoin.priceUsd.Replace(',', '.'), CultureInfo.InvariantCulture);
                SecondCoinCount = (firstCoinCount * firstCoinPrice / SecondCoinPrice).ToString();
            }
            else
            {
                MessageBox.Show("Please select two currencies to convert");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if(PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }



        private class IntermediateCoinsList
        {
            public List<Coin> data { get; set; }
        }
    }
}
