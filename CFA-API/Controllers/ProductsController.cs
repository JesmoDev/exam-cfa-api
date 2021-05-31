using CFA_API.Entities;
using CFA_API.Models;
using CFA_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace CFA_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public ProductsController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _cfaRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = _cfaRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDTO productDTO)
        {
            int id = _cfaRepository.CreateProduct(productDTO);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductUpdateDTO productDTO)
        {
            var product = _cfaRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateProduct(id, productDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _cfaRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
