using System.ComponentModel.DataAnnotations;

namespace SignalRChat.Web.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ChatMessage>? Messages { get; set; } = new List<ChatMessage>();
        public List<UserRoom>? UserRooms { get; set; } = new List<UserRoom>();
    }
}

