using Microsoft.AspNetCore.Mvc;
using LinqDatabasePractice.Models;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = _categoryService.GetAllCategories();

            var categoryDTOs = categories.Select(category => new CategoryDTO {
                Id = category.Id,
                Name = category.Name
            }).ToList();

            return Ok(categoryDTOs);
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

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        // POST: api/categories
        [HttpPost]
        public ActionResult<CategoryDTO> PostCategory([FromBody] CategoryDTO categoryDTO)
        {
            Category category = new Category 
            {
                Name = categoryDTO.Name
            };
            _categoryService.CreateCategory(category);

            var createdCategoryDTO = new CategoryDTO 
            {
                Id = category.Id,
                Name = category.Name
            };

            return CreatedAtAction(nameof(GetCategory), new { id = createdCategoryDTO.Id }, createdCategoryDTO);
        }
    }
}
