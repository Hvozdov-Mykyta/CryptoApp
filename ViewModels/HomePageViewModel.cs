using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using CryptoApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Linq;

namespace CryptoApp.ViewModels
{
    internal class HomePageViewModel : INotifyPropertyChanged
    {
        private HttpRequests http_requests;

        public HomePageViewModel() 
        {
            http_requests = new HttpRequests();
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

        public async void UpdateCoinsList()
        {
            Task<string> getTask = http_requests.GetAllAssets();
            string json = await getTask;
            IntermediateCoinsList InterCoinsList = JsonConvert.DeserializeObject<IntermediateCoinsList>(json);
            this.Coins = InterCoinsList.data.Take(10).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private class IntermediateCoinsList
        {
            public List<Coin> data { get; set; }
        }
    }
}
