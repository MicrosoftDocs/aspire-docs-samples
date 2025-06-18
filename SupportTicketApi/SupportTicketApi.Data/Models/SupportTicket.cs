using System.ComponentModel.DataAnnotations;
using NuGet.Common;

namespace SupportTicketApi.Data.Models
{
    public sealed class SupportTicket
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
}
