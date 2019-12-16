using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using board_game_api.Models;

namespace board_game_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private readonly BoardGameContext _context;

        public SquaresController(BoardGameContext context)
        {
            _context = context;
        }

        // GET: api/Squares
        [HttpGet]
        public async Task<Square[]> GetSquares()
        {
            IQueryable<Square> query = _context.Squares
                                        .Include(s => s.Players)
                                        .Include(s => s.Rule);

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        // GET: api/Squares/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSquare([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Square> query = _context.Squares
                                        .Include(s => s.Players)
                                        .Include(s => s.Rule);

            var square = await query.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

            if (square == null)
            {
                return NotFound();
            }

            return Ok(square);
        }

        // PUT: api/Squares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquare([FromRoute] int id, [FromBody] Square square)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != square.Id)
            {
                return BadRequest();
            }

            _context.Update(square);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SquareExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Squares
        [HttpPost]
        public async Task<IActionResult> PostSquare([FromBody] Square square)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Squares.Add(square);
            await _context.SaveChangesAsync();

            return Created("", square);
        }

        // DELETE: api/Squares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquare([FromRoute] int id)
        {
            // TODO: need implement

            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            // var square = await this.GetSquare(id);
            
            // if (square == null)
            // {
            //     return NotFound();
            // }

            // _context.Squares.Remove(square);
            // await _context.SaveChangesAsync();

            return Ok();
        }

        private bool SquareExists(int id)
        {
            return _context.Squares.Any(e => e.Id == id);
        }
    }
}