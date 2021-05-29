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
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public ColorsController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllColors()
        {
            var color = _cfaRepository.GetAllColors();
            return Ok(color);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetColor(int id)
        {
            var Color = _cfaRepository.GetColor(id);

            if (Color == null)
            {
                return NotFound();
            }

            return Ok(Color);
        }

        [HttpPost]
        public IActionResult CreateColor([FromBody] ProductColor color)
        {
            int id = _cfaRepository.CreateColor(color);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateColor(int id, [FromBody] ProductColor colorModel)
        {
            var color = _cfaRepository.GetColor(id);

            if (color == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateColor(id, colorModel);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteColor(int id)
        {
            var color = _cfaRepository.GetColor(id);

            if (color == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteColor(id);
            return NoContent();
        }
    }
}
