using UserProductMinimal.Interfaces;
using UserProductMinimal.Models;

namespace UserProductMinimal.Endpoints
{
    public class ProductEndpointsConfig
    {
        public static void AddEndpoints(WebApplication app)
        {
            app.MapGet("/getproducts", (IProductServices productServices, IConfiguration configuration) =>
            {
                List<Product> result = productServices.GetProducts();

                return Results.Ok(result);
            });

        }
    }
}

