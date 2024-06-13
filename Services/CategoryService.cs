using AutoMapper;
using LinqDatabasePractice.DTO;
using LinqDatabasePractice.Interfaces;
using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<CategoryDTO> GetAllCategories()
    {
        var categories = _context.Categories.ToList();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public CategoryDTO GetCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return null;
        }

        return _mapper.Map<CategoryDTO>(category);
    }

    public CategoryDTO CreateCategory(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        _context.Categories.Add(category);
        _context.SaveChanges();

        return _mapper.Map<CategoryDTO>(category);
    }
}
