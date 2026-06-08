using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SignalRChat.Web.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        public DateTime SentAt { get; set; }

        
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        public string SenderId { get; set; }
        public IdentityUser Sender { get; set; }

        public string? ReceiverId { get; set; }
        public IdentityUser? Receiver { get; set; }

        
    }
}

