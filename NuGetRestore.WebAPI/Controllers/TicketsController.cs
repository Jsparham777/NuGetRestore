using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGetRestore.WebAPI.DataStore;
using NuGetRestore.WebAPI.Filters;
using NuGetRestore.WebAPI.Models;
using NuGetRestore.WebAPI.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NuGetRestore.WebAPI.Controllers
{
    /// <summary>
    /// Ticket endpoints.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/tickets")]
    //[CustomTokenAuthFilter]
    //[Authorize]
    public class TicketsV2Controller : ControllerBase
    {
        private readonly BugsContext _db;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db">Database context.</param>
        public TicketsV2Controller(BugsContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all tickets.
        /// </summary>
        /// <returns>List of all tickets.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] TicketQueryFilter ticketQueryFilter)
        {
            IQueryable<Ticket> tickets = _db.Tickets;

            if (ticketQueryFilter != null)
            {
                if (ticketQueryFilter.Id.HasValue)
                    tickets = tickets.Where(x => x.TicketId == ticketQueryFilter.Id);

                if (!string.IsNullOrWhiteSpace(ticketQueryFilter.TitleOrDescription))
                    tickets = tickets.Where(x => x.Title.Contains(ticketQueryFilter.TitleOrDescription, StringComparison.OrdinalIgnoreCase)
                    || x.Description.Contains(ticketQueryFilter.TitleOrDescription, StringComparison.OrdinalIgnoreCase));
            }

            var result = await tickets.ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// Gets a ticket by it's ID.
        /// </summary>
        /// <param name="id">The ticket ID.</param>
        /// <returns>The <see cref="Ticket"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        /// <summary>
        /// Creates a ticket.
        /// </summary>
        /// <param name="ticket">The <see cref="Ticket"/> to create.</param>
        /// <returns></returns>
        [HttpPost]
        [TicketEnsureDescriptionPresentActionFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Ticket ticket)
        {
            await _db.Tickets.AddAsync(ticket);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ticket.TicketId }, ticket);
        }

        /// <summary>
        /// Updates a ticket for a given ID.
        /// </summary>
        /// <param name="id">The ticket ID.</param>
        /// <param name="ticket">The <see cref="Ticket"/> containing the updates.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [TicketEnsureDescriptionPresentActionFilter]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId)
                return BadRequest();

            _db.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                if (await _db.Tickets.FindAsync(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a ticket for a given ID.
        /// </summary>
        /// <param name="id">The ticket ID.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);

            if (ticket == null)
                return NotFound();

            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();

            return Ok(ticket);
        }
    }
}
