using AutoMapper;
using TopStyle_Api.Core.Interfaces;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductCreateDTO productCreateDTO)
        {
            var product = _mapper.Map<Product>(productCreateDTO);
            await _productRepo.AddProduct(product);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await _productRepo.DeleteProduct(id);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepo.GetProductById(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepo.GetProducts();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productRepo.UpdateProduct(product);
        }
    }
}
