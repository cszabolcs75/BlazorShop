using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementDBContext ctx) : base(ctx)
        {

        }

        public async Task<Product> CreateProduct(Product product)
        {
            Product tmp = product;
            Create(tmp);
            ctx.SaveChanges();
            return tmp;
        }

        public void DeleteProduct(int id)
        {
            Delete(GetOne(id));
            ctx.SaveChanges();
        }

        public Product GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> ReadAllProduct()
        {
            return GetAll();
        }

        public async Task<Product> UpdateProduct(Product product)
        {

            var ToUpdate = GetOne(product.Id);
            ToUpdate.Name = product.Name;
            ToUpdate.Price = product.Price;
            ToUpdate.ManufactureDate = product.ManufactureDate;
            ToUpdate.IsAvailable = product.IsAvailable;
            ToUpdate.StockCount = product.StockCount;
            ctx.Products.Update(ToUpdate);
            await ctx.SaveChangesAsync();
            return product;
        }
    }
}
