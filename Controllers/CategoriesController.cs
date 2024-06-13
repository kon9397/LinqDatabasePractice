using Microsoft.AspNetCore.Mvc;
using LinqDatabasePractice.DTO;
using LinqDatabasePractice.Interfaces;

namespace LinqDatabasePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: api/categories
        [HttpPost]
        public ActionResult<CategoryDTO> PostCategory([FromBody] CategoryDTO categoryDTO)
        {
            var createdCategory = _categoryService.CreateCategory(categoryDTO);

            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
        }
    }
}