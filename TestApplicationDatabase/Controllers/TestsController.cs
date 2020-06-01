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
    public class TestsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public TestsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Tests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTest()
        {
            var exams = await _context.Test.ToListAsync();
            var questions = await _context.Question.ToListAsync();
            var answers = await _context.Answer.ToListAsync();

            foreach (var exam in exams)
            {
                exam.Questions = questions.Where(x => x.TestID == exam.ID).ToList();

                foreach (var question in exam.Questions)
                {
                    question.Answers = answers.Where(x => x.QuestionId == question.Id).ToList();
                }
            }

            return exams;
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var test = await _context.Test.FindAsync(id);
            var questions = _context.Question.Where(x => x.TestID == test.ID).ToList();

            foreach (var quest in questions)
            {
                var answers = _context.Answer.Where(x => x.QuestionId == quest.Id).ToList();
                quest.Answers = answers;
            }

            test.Questions = questions;

            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        // POST: api/Tests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            _context.Test.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTest", new { id = test.ID }, test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Test>> DeleteTest(int id)
        {
            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Test.Remove(test);
            await _context.SaveChangesAsync();

            return test;
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.ID == id);
        }
    }
}
