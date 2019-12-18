using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {//OpenAPI - paczka
        private readonly s16951Context _context;
        public SalesController(s16951Context context)
        {
            _context = context;
        }




        /// <summary>
        /// Metoda zwraca listę promocji promocji
        /// </summary>
        /// <returns>
        /// Lista obiektów reprezentująca promocje
        /// </returns>
        [HttpGet]
        public IActionResult GetSales()
        {
            return Ok(_context.Promocja.ToList());
        }

        [HttpGet("{IdPromocja:int}")]
        public IActionResult GetSale(int IdPromocja)
        {

            var sale = _context.Promocja.FirstOrDefault(e => e.IdPromocja == IdPromocja);
            if (sale == null)
                return NotFound();

            return Ok(sale);
        }

        [HttpPost]
        public IActionResult Create(Promocja newSale)
        {
            _context.Promocja.Add(newSale);
            _context.SaveChanges();


            return StatusCode(201, newSale);
        }

        [HttpPut("{IdPromocja:int}")]
        public IActionResult Update(int IdPromocja,Promocja updatedSale)
        {
            if(_context.Promocja.Count(e => e.IdPromocja == IdPromocja)==0)
            {
                return NotFound();
            }

            _context.Promocja.Attach(updatedSale);
            _context.Entry(updatedSale).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSale);
        }


          [HttpDelete("{IdPromocja:int}")]
        public IActionResult Delete(int IdPromocja)
        {
            var sale = _context.Promocja.FirstOrDefault(e => e.IdPromocja == IdPromocja);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Promocja.Remove(sale);
            _context.SaveChanges();

            return Ok(sale);
        }
        
    }
}