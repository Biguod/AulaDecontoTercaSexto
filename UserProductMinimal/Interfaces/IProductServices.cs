using UserProductMinimal.Models;

namespace UserProductMinimal.Interfaces
{
    public interface IProductServices
    {
        IEnumerable<Product> GetProducts();
        Product CreateOrEditProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
    }
}
