using System.ComponentModel;
using System.Runtime.CompilerServices;
using CryptoApp.Models;

namespace CryptoApp.ViewModels
{
    internal class CoinPageViewModel : INotifyPropertyChanged
    {
        private Coin _coin;
        public Coin ActualCoin 
        {
            get { return _coin; }
            set
            {
                _coin = value;
                OnPropertyChanged("ActualCoin");
            }
        }

        public CoinPageViewModel(Coin actualCoin)
        {
            ActualCoin = actualCoin;
        }

        public CoinPageViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
