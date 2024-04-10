using Model;

namespace Logic
{
    public interface IProductLogic
    {
        Task<Result<Product>> CreateProduct(Product product);
        void DeleteProduct(int id);
        IQueryable<Product> ReadAllProduct();
        Task<Result<Product>> ReadProduct(int id);
        Task<Result<Product>> UpdateProduct(Product product);
    }
}