using SignalRChat.Web.Data;
using SignalRChat.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Web.Hubs
{
    public class ChatHub : Hub
    {
        public ApplicationDbContext dbContext { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public ChatHub(ApplicationDbContext _context, UserManager<IdentityUser> userManager)
        {
            dbContext = _context;
            UserManager = userManager;

        }

        public override async Task OnConnectedAsync()
        {
            var email = Context.User?.Identity?.Name ?? "Unknown";
            await Clients.All.SendAsync("connected", email);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var email = Context.User?.Identity?.Name ?? "Unknown";
            await Clients.All.SendAsync("disconnected", email);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task CreateRoom(string roomName)
        {
            var room = new Room { Name = roomName };
            dbContext.Rooms.Add(room);
            await dbContext.SaveChangesAsync();

            var email = Context.User?.Identity?.Name ?? "Unknown";
            await Clients.All.SendAsync("createroom", email, room.Id, room.Name);
        }

        public async Task DeleteRoom(int roomId)
        {
            var room = dbContext.Rooms.Find(roomId);
            if (room != null)
            {
                foreach (var message in dbContext.ChatMessages.Where(m => m.RoomId == roomId))
                {
                    dbContext.ChatMessages.Remove(message);
                }
                dbContext.Rooms.Remove(room);
                await dbContext.SaveChangesAsync();

                var email = Context.User?.Identity?.Name ?? "Unknown";
                await Clients.All.SendAsync("deleteroom", email, room.Id, room.Name);
                return;
            }
        }

        public async Task AddUserToRoom(int roomId)
        {
            var room = dbContext.Rooms.Find(roomId);
            if (room == null)
            {
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, room.Name);

            var principal = Context.User;
            var user = principal == null ? null : await UserManager.GetUserAsync(principal);

            if (user != null)
            {
                var alreadyExists = dbContext.UserRooms.Any(ur => ur.RoomId == roomId && ur.UserId == user.Id);
                if (!alreadyExists)
                {
                    dbContext.UserRooms.Add(new UserRoom { RoomId = roomId, UserId = user.Id });
                    await dbContext.SaveChangesAsync();
                }
            }

            var userEmail = user?.Email ?? Context.User?.Identity?.Name ?? "Unknown";
            await Clients.Caller.SendAsync("userjoined", userEmail, room.Name);
            await Clients.OthersInGroup(room.Name).SendAsync("userjoined", userEmail, room.Name);
        }

        public async Task SendPublicMessage(int roomId, string message)
        {
            var room = dbContext.Rooms.Find(roomId);
            if (room == null)
            {
                return;
            }

            var principal = Context.User;
            var user = principal == null ? null : await UserManager.GetUserAsync(principal);

            if (user != null)
            {
                dbContext.ChatMessages.Add(new ChatMessage
                {
                    Text = message,
                    SentAt = DateTime.UtcNow,
                    RoomId = roomId,
                    SenderId = user.Id
                });
                await dbContext.SaveChangesAsync();
            }

            var senderEmail = user?.Email ?? principal?.Identity?.Name ?? "Unknown";
            await Clients.Group(room.Name).SendAsync("publicmessage", senderEmail, room.Name, message);
        }

        public async Task SendPrivateMessage(string receiverEmail, string message)
        {
            var principal = Context.User;
            var sender = principal == null ? null : await UserManager.GetUserAsync(principal);
            var receiver = string.IsNullOrWhiteSpace(receiverEmail)
                ? null
                : await UserManager.FindByEmailAsync(receiverEmail);

            if (receiver != null)
            {
                var senderEmail = sender?.Email ?? principal?.Identity?.Name ?? "Unknown";
                await Clients.User(receiver.Id).SendAsync("privatemessage", senderEmail, message);

                if (sender != null)
                {
                    dbContext.ChatMessages.Add(new ChatMessage
                    {
                        Text = message,
                        SentAt = DateTime.UtcNow,
                        SenderId = sender.Id,
                        ReceiverId = receiver.Id
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task SendDesktopMessage(string message)
        {
            await Clients.All.SendAsync("desktopmessage", message);
        }



    }
}

