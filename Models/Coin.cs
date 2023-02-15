using System;
using System.Globalization;

namespace CryptoApp.Models
{
    internal class Coin
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        private string _priceUsd;
        public string priceUsd {
            get { return _priceUsd; } 
            set { _priceUsd = (String.IsNullOrEmpty(value)) ? " --- " : String.Format("{0:0.000}", double.Parse(value, CultureInfo.InvariantCulture)); }
        }

        private string _supply;
        public string supply { 
            get { return _supply; } 
            set { _supply = (String.IsNullOrEmpty(value)) ? " --- " : value.Split('.')[0]; } 
        }
        private string _maxSupply;
        public string maxSupply {
            get { return _maxSupply; }
            set { _maxSupply = (String.IsNullOrEmpty(value)) ? " --- " : value.Split('.')[0]; }
        }
        private string _volumeUsd24Hr;
        public string volumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set { _volumeUsd24Hr = (String.IsNullOrEmpty(value)) ? " --- " : String.Format("{0:0.0000}", double.Parse(value, CultureInfo.InvariantCulture)); }
        }
        private string _changePercent24Hr;
        public string changePercent24Hr
        {
            get { return _changePercent24Hr; }
            set { _changePercent24Hr = (String.IsNullOrEmpty(value)) ? " --- " : String.Format("{0:0.0000}", double.Parse(value, CultureInfo.InvariantCulture)); }
        }

        public string marketCapUsd { get; set; }
        public string vwap24Hr { get; set; }

        public string explorer { get; set; }
    }
}
