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
            return productRepository.GetAll();
        }

        public Product CreateOrEditProduct(Product product)
        {

            if (product.Id == 0)
            {
                return CreateProduct(product);

            }
            return UpdateProduct(product);
        }

        private Product CreateProduct(Product product)
        {
            var strUri = "localhost://8080/products/";//colocar url da API de email

            productRepository.Create(product);

            string request = "Produto " + product.Name + " foi criado e etá disponível em nosso estoque por " + product.Price;

            var strRequestJson = JsonConvert.SerializeObject(request);

            var reqBody = new StringBuilder();
            reqBody.Append(strRequestJson);

            HttpClientService httpClientService = new();

            string streamRet;
            httpClientService.OnRequest(EHttpVerbs.POST, strUri, reqBody);

            return product;
        }

        private Product UpdateProduct(Product product)
        {
            var strUri = "localhost://8080/products/";//colocar url da API de email

            Product oldProduct = productRepository.GetById(product.Id);

            if (oldProduct.Price > product.Price)
            {
                string request = "Produto " + product.Name + " está em promoção de" + oldProduct.Price + " por " + product.Price;

                var strRequestJson = JsonConvert.SerializeObject(request);

                var reqBody = new StringBuilder();
                reqBody.Append(strRequestJson);

                HttpClientService httpClientService = new();

                string streamRet;
                httpClientService.OnRequest(EHttpVerbs.POST, strUri, reqBody);
            }

            return productRepository.Update(product);
        }

        public Product GetProductById(int productId)
        {
            var product = productRepository.GetById(productId);
            if (product == null)
                product = new Product();
            return product;
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product.Active == false)
                return; //throw exception aqui !!!

            productRepository.Delete(product);
        }
        //var date = DateTime.Now;
        //var strUri = "localhost://8080/products";


        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("Teste/");
        //    stringBuilder.Append($"{date.ToString("yyyy-MM-ddTHH:mm:ss")}/");

        //    HttpClientService httpClientService = new();
        ////StreamReader streamRet;
        //string streamRet;
        //streamRet = httpClientService.OnRequest(EHttpVerbs.GET, strUri, stringBuilder);


        //    Product response = JsonConvert.DeserializeObject<Product>(streamRet);
    }
}
