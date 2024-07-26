using Business.Services;
using Core.Entities;
using Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryServices _categoryServices;

        public CategoryController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryDto dto)
        {
            var category = new Category {Name=dto.name };
             _categoryServices.Add(category);
            return Ok(category);
        }
    }
}
