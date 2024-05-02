using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);
            return Ok("Kategori Ekleme İşlemi Başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silme İşlemi Başarılı!");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) 
        {
           var value=_categoryService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category category) 
        {
        _categoryService.TUpdate(category);
            return Ok("Kategori Güncelleme İşlemi Başarılı!");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
            { return Ok(_categoryService.TGetCategoryCount()); }
    }
}
