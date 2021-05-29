using CFA_API.Entities;
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
    public class SizesController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public SizesController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllSizes()
        {
            var size = _cfaRepository.GetAllSizes();
            return Ok(size);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSize(int id)
        {
            var Size = _cfaRepository.GetSize(id);

            if (Size == null)
            {
                return NotFound();
            }

            return Ok(Size);
        }

        [HttpPost]
        public IActionResult CreateSize([FromBody] ProductSize size)
        {
            int id = _cfaRepository.CreateSize(size);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateSize(int id, [FromBody] ProductSize sizeModel)
        {
            var size = _cfaRepository.GetSize(id);

            if (size == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateSize(id, sizeModel);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteSize(int id)
        {
            var size = _cfaRepository.GetSize(id);

            if (size == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteSize(id);
            return NoContent();
        }
    }
}
