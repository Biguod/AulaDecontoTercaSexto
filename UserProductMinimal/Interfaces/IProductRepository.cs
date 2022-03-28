using UserProductMinimal.Models;

namespace UserProductMinimal.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Create(Product product);

        Product Update(Product product);

        Product GetById(int productId);

        void Delete(Product product);
    }
}
