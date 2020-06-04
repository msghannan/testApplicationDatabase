using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplicationDatabase.Data;
using TestApplicationDatabase.Models;
using TestApplicationDatabase.ViewModels;

namespace TestApplicationDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsResultsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public StudentsResultsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StudentsResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamHistoryViewModel>>> GetStudentsResults()
        {
            var allTests= await _context.StudentsResults.ToListAsync();
            List<ExamHistoryViewModel> exam = new List<ExamHistoryViewModel>();

            foreach(var test in allTests)
            {
                exam.Add(new ExamHistoryViewModel()
                {
                    Person = _context.Person.Where(x => x.Id == test.PersonId).FirstOrDefault(),
                    Test = _context.Test.Where(x => x.ID == test.TestId).FirstOrDefault(),
                    Grade = test.Grade,
                    Id = test.Id
                });
            }

            return exam;
        }

        // GET: api/StudentsResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsResults>> GetStudentsResults(int id)
        {
            var studentsResults = await _context.StudentsResults.FindAsync(id);

            if (studentsResults == null)
            {
                return NotFound();
            }

            return studentsResults;
        }

        // PUT: api/StudentsResults/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsResults(int id, StudentsResults studentsResults)
        {
            if (id != studentsResults.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsResults).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsResultsExists(id))
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

        // POST: api/StudentsResults
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentsResults>> PostStudentsResults(StudentsResults studentsResults)
        {
            _context.StudentsResults.Add(studentsResults);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsResults", new { id = studentsResults.Id }, studentsResults);
        }

        // DELETE: api/StudentsResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentsResults>> DeleteStudentsResults(int id)
        {
            var studentsResults = await _context.StudentsResults.FindAsync(id);
            if (studentsResults == null)
            {
                return NotFound();
            }

            _context.StudentsResults.Remove(studentsResults);
            await _context.SaveChangesAsync();

            return studentsResults;
        }

        private bool StudentsResultsExists(int id)
        {
            return _context.StudentsResults.Any(e => e.Id == id);
        }
    }
}
