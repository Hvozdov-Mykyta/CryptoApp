using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using CryptoApp.Interfaces;
using CryptoApp.Commands;
using CryptoApp.Models;
using Newtonsoft.Json;


namespace CryptoApp.ViewModels
{
    internal class CoinsPageViewModel : INotifyPropertyChanged, ICoinsPageUpdate, ICoinsPageViewSelected
    {
        private HttpRequests _httpRequests;

        public CoinsPageViewModel()
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

        private List<Coin> _filteredCoins;
        public List<Coin> FilteredCoins
        {
            get { return _filteredCoins; }
            set {
                _filteredCoins = value;
                OnPropertyChanged("FilteredCoins");
            }
        }

        private Coin _selectedCoin;
        public Coin SelectedCoin {
            get { return _selectedCoin; }
            set {
                _selectedCoin = value;
                OnPropertyChanged("SelectedCoin");
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set {
                 _searchText = value;
                 FilterCoinsList();
                 OnPropertyChanged("SearchText");
            }
        }



        private ICommand _coinsUpdater;
        public ICommand CoinsUpdate
        {
            get
            {
                if (_coinsUpdater == null)
                    _coinsUpdater = new CoinsListUpdater(this);
                return _coinsUpdater;
            }
            set { _coinsUpdater = value; }
        }

        private ICommand _coinPageOpener;
        public ICommand CoinPageOpen
        {
            get
            {
                if (_coinPageOpener == null)
                    _coinPageOpener = new CoinPageOpener(this);
                return _coinPageOpener;
            }
            set { _coinPageOpener = value; }
        }



        public async void UpdateCoinsList()
        {
            string json = await _httpRequests.GetAllAssets();
            FilteredCoins = Coins = JsonConvert.DeserializeObject<IntermediateCoinsList>(json).data;
            SearchText = "";
        }

        public void ViewSelectedCoin()
        {
            ((MainWindowViewModel)App.Current.MainWindow.DataContext).SetCoinPage(SelectedCoin);
        }

        public void FilterCoinsList()
        {
            string searchText = SearchText.ToLower();
            FilteredCoins = Coins.Where(coin => coin.name.ToLower().Contains(searchText) || coin.symbol.ToLower().Contains(searchText)).ToList();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }



        private class IntermediateCoinsList
        {
            public List<Coin> data { get; set; }
        }
    }
}
