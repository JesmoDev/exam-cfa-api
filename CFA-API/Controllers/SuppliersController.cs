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
    public class SuppliersController : ControllerBase
    {
        private readonly ICFARepository _cfaRepository;

        public SuppliersController(ICFARepository cfaRepository)
        {
            _cfaRepository = cfaRepository;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            var suppliers = _cfaRepository.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSupplier(int id)
        {
            var supplier = _cfaRepository.GetSupplier(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] Supplier supplierDTO)
        {
            int id = _cfaRepository.CreateSupplier(supplierDTO);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateSupplier(int id, [FromBody] SupplierUpdateDTO supplierDTO)
        {
            var supplier = _cfaRepository.GetSupplier(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _cfaRepository.UpdateSupplier(id, supplierDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _cfaRepository.GetSupplier(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _cfaRepository.DeleteSupplier(id);
            return NoContent();
        }
    }
}
