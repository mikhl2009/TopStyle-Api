using Microsoft.EntityFrameworkCore;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly TopStyleDbContext _context;

        public ProductRepo(TopStyleDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var productToUpdate = await _context.Products.FindAsync(product.ProductId);
            if (productToUpdate == null)
            {
                return null;
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductId = product.ProductId;

            await _context.SaveChangesAsync();
            return productToUpdate;
        }
    }
}
