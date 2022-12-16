using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/shop")]
    [ApiController]
    public class ClothingController : ControllerBase
    {
        private readonly ClothingContext _context;

        public ClothingController(ClothingContext context)
        {
            _context = context;
        }

        // GET: api/Footballers
        [HttpGet]
        public IEnumerable<Clothing> GetClothings()
        {
            return _context.Clothings;
        }

        // POST: api/Footballers
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostClothing([FromBody] Clothing clothing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int local_day = 16;
            int local_mounth = 12;
            int local_year = 2022;

            if(local_mounth != clothing.Delivery_mounth)
            {
                int discount = ((10 * (clothing.Delivery_mounth - local_mounth)) * clothing.Price) / 100;
                clothing.Price_with_discount = discount;
            }

            _context.Clothings.Add(clothing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClothings), new { id = clothing.Id }, clothing);
        }

        // DELETE: api/Footballers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var footballer = await _context.Clothings.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }

            _context.Clothings.Remove(footballer);
            await _context.SaveChangesAsync();

            return Ok(footballer);
        }

        private bool ClothingExists(int id)
        {
            return _context.Clothings.Any(e => e.Id == id);
        }
    }
}