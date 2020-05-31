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
    public class AnswersController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public AnswersController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswer()
        {
            return await _context.Answer.ToListAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            var answer = await _context.Answer.FindAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            if (id != answer.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(answer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        //{
        //    _context.Answer.Add(answer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAnswer", new { id = answer.AnswerId }, answer);
        //}
        public async Task<ActionResult<List<Answer>>> PostAnswer(List<Answer> answerList)


        {
            foreach (var a in answerList)
            {


                var test = _context.Answer.Add(a);

            }
            var abc = await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Answer>> DeleteAnswer(int id)
        {
            var answer = await _context.Answer.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();

            return answer;
        }

        private bool AnswerExists(int id)
        {
            return _context.Answer.Any(e => e.AnswerId == id);
        }
    }
}
