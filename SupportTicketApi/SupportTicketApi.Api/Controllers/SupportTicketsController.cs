using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTicketApi.Data.Contexts;
using SupportTicketApi.Data.Models;

namespace SupportTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketsController : ControllerBase
    {
        private readonly TicketContext _context;

        public SupportTicketsController(TicketContext context)
        {
            _context = context;
        }

        // GET: api/SupportTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/SupportTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicket>> GetSupportTicket(int id)
        {
            var supportTicket = await _context.Tickets.FindAsync(id);

            if (supportTicket == null)
            {
                return NotFound();
            }

            return supportTicket;
        }

        // PUT: api/SupportTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportTicket(int id, SupportTicket supportTicket)
        {
            if (id != supportTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketExists(id))
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

        // POST: api/SupportTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupportTicket>> PostSupportTicket(SupportTicket supportTicket)
        {
            _context.Tickets.Add(supportTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupportTicket", new { id = supportTicket.Id }, supportTicket);
        }

        // DELETE: api/SupportTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportTicket(int id)
        {
            var supportTicket = await _context.Tickets.FindAsync(id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(supportTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportTicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
