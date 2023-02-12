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
    }
}
