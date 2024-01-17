using Microsoft.AspNetCore.SignalR;

namespace BlazorChat2.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",userName, message);
        }

        public async Task SendMessageSelf(string userName, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", userName, message);
        }

        public async Task JoinRoom(string roomName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", userName + " joined the chatroom");
        }

        public async Task LeaveRoom(string roomName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", userName + " left the chatroom");
        }

        public async Task SendToRoom(string roomName, string userName,string message)
        {
            await Clients.Group(roomName).SendAsync("ReceiveMessage", userName, message);
        }
    }
}
