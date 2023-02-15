using System.Net.Http;
using System.Threading.Tasks;


namespace CryptoApp.Models
{
    internal class HttpRequests
    {
        private const string _allAssetsUrl = "https://api.coincap.io/v2/assets";


        public async Task<string> GetAllAssets()
        {
            return await MakeRestRequest(_allAssetsUrl);
        }

        public async Task<string> GetAllCoinMarkets(string coinId)
        {
            return await MakeRestRequest(_allAssetsUrl + "/" + coinId + "/markets");
        }

        public async Task<string> GetOneCoin(string coinId)
        {
            return await MakeRestRequest(_allAssetsUrl + "/" + coinId);
        }

        private async Task<string> MakeRestRequest(string url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}
