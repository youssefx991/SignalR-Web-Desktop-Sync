using SignalRChat.Desktop.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRChat.Desktop
{
    public partial class Form1 : Form
    {
        HubConnection conn;
        private readonly Task connectionReady;

        public Form1()
        {
            InitializeComponent();
            conn = new HubConnectionBuilder().WithUrl("https://localhost:7100/chathub").Build();
            ConfigureRoomComboBox(cb_addusertoroomname);
            ConfigureRoomComboBox(cb_deleteroomname);
            ConfigureRoomComboBox(cb_publicmsgroomname);

            conn.On<string>("desktopmessage", (message) =>
            {
                listBox1.Invoke(() =>
                {
                    listBox1.Items.Add(message);
                });
            });

            conn.On<string>("connected", (msg) =>
            {
                listBox1.Invoke(() =>
                {
                    listBox1.Items.Add($"User connected: {msg}");
                });
            });

            conn.On<string>("disconnected", (msg) =>
            {
                listBox1.Invoke(() =>
                {
                    listBox1.Items.Add($"User disconnected: {msg}");
                });
            });


            conn.On<string, int, string>("createroom", (email, roomId, roomName) =>
            {
                listBox1.Invoke(() =>
                {
                    var room = new CreateRoomModel
                    {
                        email = email,
                        roomId = roomId,
                        roomName = roomName
                    };

                    listBox1.Items.Add($"Room created by {email}: {room.roomName}");

                    AddRoomToComboBox(cb_addusertoroomname, room);
                    AddRoomToComboBox(cb_deleteroomname, room);
                    AddRoomToComboBox(cb_publicmsgroomname, room);
                });
            });

            conn.On<string, int, string>("deleteroom", (email, roomId, roomName) =>
            {
                listBox1.Invoke(() =>
                {
                    var room = new CreateRoomModel
                    {
                        email = email,
                        roomId = roomId,
                        roomName = roomName
                    };

                    listBox1.Items.Add($"Room deleted by {email}: {room.roomName}");

                    RemoveRoomFromComboBox(cb_addusertoroomname, room.roomId);
                    RemoveRoomFromComboBox(cb_deleteroomname, room.roomId);
                    RemoveRoomFromComboBox(cb_publicmsgroomname, room.roomId);
                });
            });

            conn.On<string, string>("userjoined", (email, roomName) =>
            {
                listBox1.Invoke(() =>
                {
                    listBox1.Items.Add($"User joined room {roomName}: {email}");
                });
            });

            conn.On<string, string, string>("publicmessage", (email, roomName, message) =>
            {
                listBox1.Invoke(() =>
                {
                    listBox1.Items.Add($"Public message in {roomName}: {email} - {message}");
                });
            });

            conn.On<string, string>("privatemessage", (Senderemail, message) =>
            {
                listBox1.Invoke(() =>
                {
                    listBox1.Items.Add($"Private message from {Senderemail}: {message}");
                });
            });





            connectionReady = conn.StartAsync();


        }

        private async void btn_createroom_Click(object sender, EventArgs e)
        {
            var roomName = tb_roomname.Text.Trim();
            if (string.IsNullOrWhiteSpace(roomName))
            {
                return;
            }

            try
            {
                await connectionReady;
                await conn.InvokeAsync("CreateRoom", roomName);
                tb_roomname.Clear();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"CreateRoom failed: {ex.Message}");
            }
        }

        private async void btn_sendpublicmessage_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedRoomId(cb_publicmsgroomname, out var roomId))
            {
                listBox1.Items.Add("SendPublicMessage failed: select a valid room first.");
                return;
            }

            try
            {
                await connectionReady;
                await conn.InvokeAsync("SendPublicMessage", roomId, tb_publicmessage.Text);
                tb_publicmessage.Clear();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"SendPublicMessage failed: {ex.Message}");
            }
        }

        private async void btn_deleteroom_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedRoomId(cb_deleteroomname, out var roomId))
            {
                listBox1.Items.Add("DeleteRoom failed: select a valid room first.");
                return;
            }

            try
            {
                await connectionReady;
                await conn.InvokeAsync("DeleteRoom", roomId);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"DeleteRoom failed: {ex.Message}");
            }

        }

        private async void btn_addusertroom_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedRoomId(cb_addusertoroomname, out var roomId))
            {
                listBox1.Items.Add("AddUserToRoom failed: select a valid room first.");
                return;
            }

            try
            {
                await connectionReady;
                await conn.InvokeAsync("AddUserToRoom", roomId);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"AddUserToRoom failed: {ex.Message}");
            }
        }

        private static void ConfigureRoomComboBox(ComboBox comboBox)
        {
            comboBox.DisplayMember = "roomName";
            comboBox.ValueMember = "roomId";
        }

        private static void AddRoomToComboBox(ComboBox comboBox, CreateRoomModel room)
        {
            foreach (var item in comboBox.Items)
            {
                if (item is CreateRoomModel existing && existing.roomId == room.roomId)
                {
                    return;
                }
            }

            comboBox.Items.Add(room);
            if (comboBox.SelectedIndex < 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private static void RemoveRoomFromComboBox(ComboBox comboBox, int roomId)
        {
            for (var i = comboBox.Items.Count - 1; i >= 0; i--)
            {
                if (comboBox.Items[i] is CreateRoomModel room && room.roomId == roomId)
                {
                    comboBox.Items.RemoveAt(i);
                }
            }

            if (comboBox.Items.Count > 0 && comboBox.SelectedIndex < 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private static bool TryGetSelectedRoomId(ComboBox comboBox, out int roomId)
        {
            if (comboBox.SelectedItem is CreateRoomModel selectedRoom)
            {
                roomId = selectedRoom.roomId;
                return true;
            }

            var selectedText = comboBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                foreach (var item in comboBox.Items)
                {
                    if (item is CreateRoomModel room && string.Equals(room.roomName, selectedText, StringComparison.OrdinalIgnoreCase))
                    {
                        roomId = room.roomId;
                        return true;
                    }
                }
            }

            roomId = 0;
            return false;
        }

        private async void btn_sendprivatemessage_Click(object sender, EventArgs e)
        {
            var receiverEmail = tb_privatemessageuseremail.Text?.Trim();
            if (string.IsNullOrWhiteSpace(receiverEmail))
            {
                listBox1.Items.Add("SendPrivateMessage failed: enter a valid receiver email first.");
                return;
            }

            try
            {
                await connectionReady;
                await conn.InvokeAsync("SendPrivateMessage", receiverEmail, tb_privatemsg.Text);
                tb_privatemsg.Clear();
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"SendPrivateMessage failed: {ex.Message}");
            }
        }
    }
}

