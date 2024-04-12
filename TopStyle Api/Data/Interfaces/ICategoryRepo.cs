using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);

    }
}
