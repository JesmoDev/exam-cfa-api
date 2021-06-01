using CFA_API.Entities;
using CFA_API.Models;
using CFA_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public CategoriesController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _cfaRepository.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var category = _cfaRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category categoryDTO)
        {
            int id = _cfaRepository.CreateCategory(categoryDTO);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDTO categoryDTO)
        {
            var category = _cfaRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateCategory(id, categoryDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _cfaRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteCategory(id);
            return NoContent();
        }
    }
}
