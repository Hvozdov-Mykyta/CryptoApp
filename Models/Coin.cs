namespace CryptoApp.Models
{
    internal class Coin
    {
        private string _id;
        public string id 
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _rank;
        public string rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _supply;
        public string supply
        {
            get { return _supply; }
            set { _supply = value; }
        }

        private string _maxSupply;
        public string maxSupply
        {
            get { return _maxSupply; }
            set { _maxSupply = value; }
        }

        private string _marketCapUsd;
        public string marketCapUsd
        {
            get { return _marketCapUsd; }
            set { _marketCapUsd = value; }
        }

        private string _volumeUsd24Hr;
        public string volumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set { _volumeUsd24Hr = value; }
        }

        private string _priceUsd;
        public string priceUsd
        {
            get { return _priceUsd; }
            set { _priceUsd = value; }
        }

        private string _changePercent24Hr;
        public string changePercent24Hr
        {
            get { return _changePercent24Hr; }
            set { _changePercent24Hr = value; }
        }

        private string _vwap24Hr;
        public string vwap24Hr
        {
            get { return _vwap24Hr; }
            set { _vwap24Hr = value; }
        }

        private string _explorer;
        public string explorer
        {
            get { return _explorer; }
            set { _explorer = value; }
        }
    }
}
