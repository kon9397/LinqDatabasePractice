using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Interfaces;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories();
    Category GetCategory(int id);
    Category CreateCategory(Category category);
}