using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly TopStyleDbContext _context;

        public CategoryRepo(TopStyleDbContext context)
        {
            _context = context;
        }
        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public Task<Category> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
