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
    public class PersonTestsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public PersonTestsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PersonTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonTest>>> GetPersonTest()
        {
            return await _context.PersonTest.ToListAsync();
        }

        // GET: api/PersonTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonTest>> GetPersonTest(int id)
        {
            var personTest = await _context.PersonTest.FindAsync(id);

            if (personTest == null)
            {
                return NotFound();
            }

            return personTest;
        }

        // PUT: api/PersonTests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonTest(int id, PersonTest personTest)
        {
            if (id != personTest.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonTestExists(id))
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

        // POST: api/PersonTests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonTest>> PostPersonTest(PersonTest personTest)
        {
            _context.PersonTest.Add(personTest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonTestExists(personTest.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonTest", new { id = personTest.PersonId }, personTest);
        }

        // DELETE: api/PersonTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonTest>> DeletePersonTest(int id)
        {
            var personTest = await _context.PersonTest.FindAsync(id);
            if (personTest == null)
            {
                return NotFound();
            }

            _context.PersonTest.Remove(personTest);
            await _context.SaveChangesAsync();

            return personTest;
        }

        private bool PersonTestExists(int id)
        {
            return _context.PersonTest.Any(e => e.PersonId == id);
        }
    }
}
