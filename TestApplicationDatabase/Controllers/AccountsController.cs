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
    public class AccountsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public AccountsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        // Actually Creates the account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount(Person person)
        {
            _context.Person.Add(person);
           var result = await _context.SaveChangesAsync();

            if(result > 0)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        // GET: api/Accounts/5
        //[HttpGet]
        //public async Task<ActionResult<Person>> GetAccount(Account acc)
        //{

        //}

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Person>> PostAccount(Account acc)
        {

            var account = _context.Account.Where(x => x.Username == acc.Username).First();

            if (account == null)
            {
                return NotFound();
            }

            var person = _context.Person.Where(x => x.Account == account).FirstOrDefault();
            person.Role = _context.Role.Where(x => x.PersonId == person.Id).FirstOrDefault();

            return person;
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
    }
}
