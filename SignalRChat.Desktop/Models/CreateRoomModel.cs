using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRChat.Desktop.Models
{
    public class CreateRoomModel
    {
        public string email { get; set; }
        public int roomId { get; set; }
        public string roomName { get; set; }
    }
}

