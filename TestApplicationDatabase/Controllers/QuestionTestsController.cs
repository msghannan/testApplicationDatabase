using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplicationDatabase.Data;
using TestApplicationDatabase.Models;

namespace TestApplicationDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTestsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public QuestionTestsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/QuestionTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionTest>>> GetQuestionTest()
        {
            return await _context.QuestionTest.ToListAsync();
        }

        // GET: api/QuestionTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionTest>> GetQuestionTest(int id)
        {
            var questionTest = await _context.QuestionTest.FindAsync(id);

            if (questionTest == null)
            {
                return NotFound();
            }

            return questionTest;
        }

        // PUT: api/QuestionTests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionTest(int id, QuestionTest questionTest)
        {
            if (id != questionTest.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(questionTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTestExists(id))
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

        // POST: api/QuestionTests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuestionTest>> PostQuestionTest(QuestionTest questionTest)
        {
            _context.QuestionTest.Add(questionTest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionTestExists(questionTest.QuestionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestionTest", new { id = questionTest.QuestionId }, questionTest);
        }

        // DELETE: api/QuestionTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionTest>> DeleteQuestionTest(int id)
        {
            var questionTest = await _context.QuestionTest.FindAsync(id);
            if (questionTest == null)
            {
                return NotFound();
            }

            _context.QuestionTest.Remove(questionTest);
            await _context.SaveChangesAsync();

            return questionTest;
        }

        private bool QuestionTestExists(int id)
        {
            return _context.QuestionTest.Any(e => e.QuestionId == id);
        }
    }
}
