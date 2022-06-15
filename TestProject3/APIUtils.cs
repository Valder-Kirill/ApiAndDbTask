using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DBAndAPIProject
{
    public class APIUtils
    {
        private string BaseURL = @GetTestData.Get("APIValues", "BaseURL");

        public string GetAllСurrencys()
        {
            using (var webClient = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") })
            {
                BaseURL += @GetTestData.Get("APIValues", "AllСurrencysURL");
                return webClient.DownloadString(BaseURL);
            }
        }

        public List<СurrencyModel> GetListModels()
        {
            return JsonConvert.DeserializeObject<List<СurrencyModel>>(GetAllСurrencys());
        }
    }
}
