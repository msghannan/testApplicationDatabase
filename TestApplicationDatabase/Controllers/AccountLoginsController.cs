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
    public class AccountLoginsController : ControllerBase
    {
        private readonly TestApplicationDatabaseContext _context;

        public AccountLoginsController(TestApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AccountLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountLogin>>> GetAccountLogin()
        {
            return await _context.AccountLogin.ToListAsync();
        }

        // GET: api/AccountLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountLogin>> GetAccountLogin(int id)
        {
            var accountLogin = await _context.AccountLogin.FindAsync(id);

            if (accountLogin == null)
            {
                return NotFound();
            }

            return accountLogin;
        }

        // PUT: api/AccountLogins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountLogin(int id, AccountLogin accountLogin)
        {
            if (id != accountLogin.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountLoginExists(id))
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

        // POST: api/AccountLogins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountLogin>> PostAccountLogin(AccountLogin accountLogin)
        {
            _context.AccountLogin.Add(accountLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountLogin", new { id = accountLogin.Id }, accountLogin);
        }

        // DELETE: api/AccountLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountLogin>> DeleteAccountLogin(int id)
        {
            var accountLogin = await _context.AccountLogin.FindAsync(id);
            if (accountLogin == null)
            {
                return NotFound();
            }

            _context.AccountLogin.Remove(accountLogin);
            await _context.SaveChangesAsync();

            return accountLogin;
        }

        private bool AccountLoginExists(int id)
        {
            return _context.AccountLogin.Any(e => e.Id == id);
        }
    }
}
