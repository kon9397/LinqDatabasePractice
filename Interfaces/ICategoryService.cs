using LinqDatabasePractice.DTO;
using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDTO> GetAllCategories();
    CategoryDTO GetCategory(int id);
    CategoryDTO CreateCategory(CategoryDTO category);
}