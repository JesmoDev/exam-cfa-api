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
    public class BrandsController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public BrandsController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var brands = _cfaRepository.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBrand(int id)
        {
            var brand = _cfaRepository.GetBrand(id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        public IActionResult CreateBrand([FromBody] Brand brandDTO)
        {
            int id = _cfaRepository.CreateBrand(brandDTO);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBrand(int id, [FromBody] BrandUpdateDTO brandDTO)
        {
            var brand = _cfaRepository.GetBrand(id);

            if (brand == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateBrand(id, brandDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBrand(int id)
        {
            var brand = _cfaRepository.GetBrand(id);

            if (brand == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteBrand(id);
            return NoContent();
        }
    }
}
