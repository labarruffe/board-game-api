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
    public class BoardGameController : ControllerBase
    {
        private readonly BoardGameContext _context;

        public BoardGameController(BoardGameContext context)
        {
            _context = context;
        }

        // GET: api/BoardGame
        [HttpGet]
        public async Task<BoardGame[]> GetBoardGame()
        {
            IQueryable<BoardGame> query = _context.BoardGame
                                    .Include(bg => bg.Squares)
                                    .Include(bg => bg.Participants);

            query = query.AsNoTracking().OrderBy(bg => bg.Id);

            return await query.ToArrayAsync();
        }

        // GET: api/BoardGame/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoardGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boardGame = await _context.BoardGame.FindAsync(id);

            if (boardGame == null)
            {
                return NotFound();
            }

            return Ok(boardGame);
        }

        // PUT: api/BoardGame/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoardGame([FromRoute] int id, [FromBody] BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(boardGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardGameExists(id))
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

        // POST: api/BoardGame
        [HttpPost]
        public async Task<IActionResult> PostBoardGame([FromBody] BoardGame boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BoardGame.Add(boardGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoardGame", new { id = boardGame.Id }, boardGame);
        }

        // DELETE: api/BoardGame/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoardGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boardGame = await _context.BoardGame.FindAsync(id);
            if (boardGame == null)
            {
                return NotFound();
            }

            _context.BoardGame.Remove(boardGame);
            await _context.SaveChangesAsync();

            return Ok(boardGame);
        }

        private bool BoardGameExists(int id)
        {
            return _context.BoardGame.Any(e => e.Id == id);
        }
    }
}