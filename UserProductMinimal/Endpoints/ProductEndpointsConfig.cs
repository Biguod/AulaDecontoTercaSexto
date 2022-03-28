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
                var result = productServices.GetProducts();

                return Results.Ok(result);
            });

            app.MapPost("/createoreditprocut", (IProductServices productServices, IConfiguration configuration, string productName, string productDescription, decimal productPrice, bool productActive, int productId) =>
            {
                Product product = new Product()
                {
                    Id = productId != 0 ? productId : 0,
                    Name = productName,
                    Description = productDescription,
                    Price = productPrice,
                    Active = productActive
                };

                productServices.CreateOrEditProduct(product);

                return Results.Ok(product);
            });

            app.MapGet("/getproductbyid", (IProductServices productServices, IConfiguration configuration, int productId) =>
            {
                var product = productServices.GetProductById(productId);

                return Results.Ok(product);
            });

            app.MapDelete("/deleteproduct", (IProductServices productServices, IConfiguration configuration, int productId) =>
            {
                productServices.DeleteProduct(productId);

                return Results.Ok();
            });

        }
    }
}

