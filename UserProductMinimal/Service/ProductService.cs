using System.Text;
using UserProductMinimal.Models;
using Newtonsoft.Json;
using UserProductMinimal.Enum;
using UserProductMinimal.Interfaces;

namespace UserProductMinimal.Service
{
    public class ProductService : IProductServices
    {
        public List<Product> GetProducts()
        {
            var date = DateTime.Now;
            var strUri = "localhost://8080/products";


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Teste/");
            stringBuilder.Append($"{date.ToString("yyyy-MM-ddTHH:mm:ss")}/");

            HttpClientService httpClientService = new();
            //StreamReader streamRet;
            string streamRet;
            streamRet = httpClientService.OnRequest(EHttpVerbs.GET, strUri, stringBuilder);


            Product response = JsonConvert.DeserializeObject<Product>(streamRet);

            return new List<Product>();
        }
    }
}
