using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using Newtonsoft.Json;
using CryptoApp.Models;
using CryptoApp.Commands;
using CryptoApp.Interfaces;

namespace CryptoApp.ViewModels
{
    internal class HomePageViewModel : INotifyPropertyChanged, ICoinsPage
    {
        private HttpRequests _httpRequests;

        public HomePageViewModel() 
        {
            _httpRequests = new HttpRequests();
            UpdateCoinsList();
        }


        private List<Coin> _coins;
        public List<Coin> Coins 
        { 
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged("Coins");
            }
        }

        private Coin _selectedCoin;
        public Coin SelectedCoin
        {
            get { return _selectedCoin; }
            set
            {
                _selectedCoin = value;
                OnPropertyChanged("SelectedCoin");
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

        public async void UpdateCoinsList()
        {
            Task<string> getTask = _httpRequests.GetAllAssets();
            string json = await getTask;
            Coins = JsonConvert.DeserializeObject<IntermediateCoinsList>(json).data.Take(10).ToList();
        }


        private ICommand _coinPageOpener;
        public ICommand CoinPageOpen
        {
            get
            {
                if(_coinPageOpener == null)
                    _coinPageOpener= new CoinPageOpener(this);
                return _coinPageOpener;
            }
            set { _coinPageOpener = value; }
        }

        public void ViewSelectedCoin()
        {
            ((MainWindowViewModel)App.Current.MainWindow.DataContext).SetCoinPage(_selectedCoin);
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
