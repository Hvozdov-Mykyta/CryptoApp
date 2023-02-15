using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    internal class HttpRequests
    {
        private const string _allAssetsUrl = "https://api.coincap.io/v2/assets";


        public async Task<string> GetAllAssets()
        {
            HttpClient client = new HttpClient();

            var returnMessage = await client.GetStringAsync(_allAssetsUrl);

            return returnMessage;
        }

        public async Task<string> GetAllCoinMarkets(string coinId)
        {
            HttpClient client = new HttpClient();

            var returnMessage = await client.GetStringAsync(_allAssetsUrl + "/" + coinId + "/markets");

            return returnMessage;
        }

        public async Task<string> GetOneCoin(string coinId)
        {
            HttpClient client = new HttpClient();

            var returnMessage = await client.GetStringAsync(_allAssetsUrl + "/" + coinId);

            return returnMessage;
        }
    }
}
