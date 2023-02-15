using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using CryptoApp.Models;
using CryptoApp.Commands;
using Newtonsoft.Json;


namespace CryptoApp.ViewModels
{
    internal class CoinPageViewModel : INotifyPropertyChanged
    {
        private HttpRequests _httpRequests;

        public CoinPageViewModel()
        {
            _httpRequests = new HttpRequests();
        }



        private Coin _actualCoin;
        public Coin ActualCoin 
        {
            get { return _actualCoin; }
            set {
                _actualCoin = value;
                OnPropertyChanged("ActualCoin");
            }
        }

        private List<Market> _coinMarkets;
        public List<Market> CoinMarkets
        {
            get { return _coinMarkets; }
            set { 
                _coinMarkets = value;
                OnPropertyChanged("CoinMarkets");
            }
        }



        private ICommand _coinUpdater;
        public ICommand CoinUpdate
        {
            get
            {
                if (_coinUpdater == null)
                    _coinUpdater = new CoinPageUpdater(this);
                return _coinUpdater;
            }
            set { _coinUpdater = value; }
        }



        public async void UpdateActualCoin()
        {
            string json = await _httpRequests.GetOneCoin(ActualCoin.id);
            ActualCoin = JsonConvert.DeserializeObject<IntermediateCoinClass>(json).data;
        }

        public async void LoadMarketsList()
        {
            string json = await _httpRequests.GetAllCoinMarkets(ActualCoin.id);
            CoinMarkets = JsonConvert.DeserializeObject<IntermediateMarketsList>(json).data;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }



        private class IntermediateCoinClass
        {
            public Coin data { get; set; }
        }

        private class IntermediateMarketsList
        {
            public List<Market> data { get; set; }
        }
    }
}
