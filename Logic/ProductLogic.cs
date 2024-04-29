using Model;
using Repository;
using System.Diagnostics;
using System.Xml.Linq;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        IProductRepository _productRepository;
        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<Result<Product>> CreateProduct(Product product)
        {
            var validationResult = await product.Validate();
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var existingName = _productRepository.GetAll().FirstOrDefault(x=> x.Name == product.Name);

            if (existingName != null)
            {
                return Result<Product>.Fail("There is a product with that name!");
            }
            else
            {
                var createdProduct = await _productRepository.CreateProduct(product);
                return Result<Product>.Success(createdProduct);
            }
        }

        public async void DeleteProduct(int id)
        {            
             await ReadProduct(id);
             _productRepository.DeleteProduct(id);
        }


        public IQueryable<Product> ReadAllProduct()
        {
            return _productRepository.ReadAllProduct();
        }

        public async Task<Result<Product>> ReadProduct(int id)
        {
            var item = _productRepository.GetOne(id);
            if (item != null)
            {
                return Result<Product>.Success(item);
            }
            else
            {
                return Result<Product>.Fail("There is not any product with that ID!");
            }
 
        }
        public async Task<Result<Product>> UpdateProduct(Product product)
        {
            var validationResult = await product.Validate();
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            await ReadProduct(product.Id);

            var existingName = _productRepository.GetAll().FirstOrDefault(x => x.Name == product.Name && x.Id != product.Id);

            if (existingName != null)
            {
                return Result<Product>.Fail("There is a product with that name!");
            }
            else
            {
                var updatedProduct = await _productRepository.UpdateProduct(product);
                return Result<Product>.Success(updatedProduct);
            }       
            
        }
    }
}
