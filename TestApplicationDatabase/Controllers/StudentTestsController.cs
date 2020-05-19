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
    public class StudentTestsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public StudentTestsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StudentTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentTest>>> GetStudentTest()
        {
            return await _context.StudentTest.ToListAsync();
        }

        // GET: api/StudentTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTest>> GetStudentTest(int id)
        {
            var studentTest = await _context.StudentTest.FindAsync(id);

            if (studentTest == null)
            {
                return NotFound();
            }

            return studentTest;
        }

        // PUT: api/StudentTests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentTest(int id, StudentTest studentTest)
        {
            if (id != studentTest.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTestExists(id))
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

        // POST: api/StudentTests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentTest>> PostStudentTest(StudentTest studentTest)
        {
            _context.StudentTest.Add(studentTest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentTestExists(studentTest.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentTest", new { id = studentTest.StudentId }, studentTest);
        }

        // DELETE: api/StudentTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentTest>> DeleteStudentTest(int id)
        {
            var studentTest = await _context.StudentTest.FindAsync(id);
            if (studentTest == null)
            {
                return NotFound();
            }

            _context.StudentTest.Remove(studentTest);
            await _context.SaveChangesAsync();

            return studentTest;
        }

        private bool StudentTestExists(int id)
        {
            return _context.StudentTest.Any(e => e.StudentId == id);
        }
    }
}
