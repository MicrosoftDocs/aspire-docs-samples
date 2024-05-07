using Microsoft.EntityFrameworkCore;
using SupportTicketApi.Data.Models;

namespace SupportTicketApi.Data.Contexts
{
    public class TicketContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<SupportTicket> Tickets => Set<SupportTicket>();
    }
}
