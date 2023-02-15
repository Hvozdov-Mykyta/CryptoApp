using System.Globalization;
using System;

namespace CryptoApp.Models
{
    internal class Market
    {
        public string exchangeId { get; set; }
        public string baseId { get; set; }
        public string quoteId { get; set; }
        public string baseSymbol { get; set; }
        public string quoteSymbol { get; set; }

        private string _volumeUsd24Hr;
        public string volumeUsd24Hr { 
            get { return _volumeUsd24Hr; } 
            set { _volumeUsd24Hr = (String.IsNullOrEmpty(value)) ? " --- " : String.Format("{0:0.000}", double.Parse(value, CultureInfo.InvariantCulture)); } 
        }

        private string _priceUsd;
        public string priceUsd {
            get { return _priceUsd; }
            set { _priceUsd = (String.IsNullOrEmpty(value)) ? " --- " : String.Format("{0:0.000}", double.Parse(value, CultureInfo.InvariantCulture)); }
        }

        private string _volumePercent;
        public string volumePercent { 
            get { return _volumePercent; }
            set { _volumePercent = (String.IsNullOrEmpty(value)) ? " --- " : String.Format("{0:0.000}", double.Parse(value, CultureInfo.InvariantCulture)); }
        }
    }
}
