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
    public class RulesController : ControllerBase
    {
        private readonly BoardGameContext _context;

        public RulesController(BoardGameContext context)
        {
            _context = context;
        }

        // GET: api/Rules
        [HttpGet]
        public IEnumerable<Rule> GetRules()
        {
            return _context.Rules;
        }

        // GET: api/Rules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rule = await _context.Rules.FindAsync(id);

            if (rule == null)
            {
                return NotFound();
            }

            return Ok(rule);
        }

        // PUT: api/Rules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRule([FromRoute] int id, [FromBody] Rule rule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rule.Id)
            {
                return BadRequest();
            }

            _context.Entry(rule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuleExists(id))
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

        // POST: api/Rules
        [HttpPost]
        public async Task<IActionResult> PostRule([FromBody] Rule rule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rules.Add(rule);
            await _context.SaveChangesAsync();

            return Created("", rule);
        }

        // DELETE: api/Rules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rule = await _context.Rules.FindAsync(id);
            if (rule == null)
            {
                return NotFound();
            }

            _context.Rules.Remove(rule);
            await _context.SaveChangesAsync();

            return Ok(rule);
        }

        private bool RuleExists(int id)
        {
            return _context.Rules.Any(e => e.Id == id);
        }
    }
}