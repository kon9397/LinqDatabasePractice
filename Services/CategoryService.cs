using LinqDatabasePractice.Interfaces;
using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        var category = _context.Categories.Find(id);
        return category;
    }

    public Category CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();

        return category;
    }
}
