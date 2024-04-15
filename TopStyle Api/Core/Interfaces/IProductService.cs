using Microsoft.AspNetCore.Http.HttpResults;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Core.Interfaces
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(ProductCreateDTO productCreateDTO);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProductByTitleAsync(string title);
    }
}
