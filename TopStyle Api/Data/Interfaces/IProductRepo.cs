using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Interfaces
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<Product> DeleteProduct(int id);
        public Task<IEnumerable<Product>> GetProductByTitleAsync(string title);

    }
}
