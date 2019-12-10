using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private s16951Context _context;
        public SalesController(s16951Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            return Ok(_context.Promocja.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSale(int id)
        {

            var sale = _context.Promocja.FirstOrDefault(e => e.IdPromocja == id);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }
    }
}