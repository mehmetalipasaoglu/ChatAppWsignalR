using Microsoft.AspNetCore.SignalR;

namespace ChatAppWsignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string roomName)
        {
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinGroup(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task LeaveGroup(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
