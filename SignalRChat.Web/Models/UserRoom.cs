using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SignalRChat.Web.Models
{
    [PrimaryKey(nameof(UserId), nameof(RoomId))]
    public class UserRoom
    {
        [Key]
        public string UserId { get; set; } = string.Empty;
        public IdentityUser User { get; set; } = null!;

        [Key]
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}

