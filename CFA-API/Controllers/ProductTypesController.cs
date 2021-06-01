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
    [Route("/types")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public ProductTypesController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            var productTypes = _cfaRepository.GetAllProductTypes();
            return Ok(productTypes);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductType(int id)
        {
            var productType = _cfaRepository.GetProductType(id);

            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        [HttpPost]
        public IActionResult CreateProductType([FromBody] ProductType productTypeDTO)
        {
            int id = _cfaRepository.CreateProductType(productTypeDTO);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProductType(int id, [FromBody] ProductTypeUpdateDTO productTypeDTO)
        {
            var productType = _cfaRepository.GetProductType(id);

            if (productType == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateProductType(id, productTypeDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProductType(int id)
        {
            var productType = _cfaRepository.GetProductType(id);

            if (productType == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteProductType(id);
            return NoContent();
        }
    }
}
