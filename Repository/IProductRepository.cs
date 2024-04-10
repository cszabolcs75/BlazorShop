using Model;

namespace Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> CreateProduct(Product product);
        void DeleteProduct(int id);
        Product GetOne(int id);
        IQueryable<Product> ReadAllProduct();
        Task<Product> UpdateProduct(Product product);
    }
}