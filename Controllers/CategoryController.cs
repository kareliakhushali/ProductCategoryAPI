using Microsoft.AspNetCore.Mvc;
using Product_Mini.Models.Domain;
using Product_Mini.Models.DTOs;
using Product_Mini.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Mini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _categoryRepository.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")] //api/category/getbyid/1
        public IActionResult GetById(int id)
        {
            var data = _categoryRepository.GetById(id);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddUpdate(Category model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Validation failed";
            }
            var result = _categoryRepository.AddUpdate(model);

            status.StatusCode = result ? 1 : 0;
            status.Message = result ? "Saved Successfully" : "Error has occured";
            return Ok(status);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryRepository.Delete(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                Message = result ? "Deleted successfully" : "Error has occured"
            };
            return Ok(status);

        }
}
    }

