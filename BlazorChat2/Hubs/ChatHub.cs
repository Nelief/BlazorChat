using Microsoft.AspNetCore.SignalR;

namespace BlazorChat2.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string userName, string message)
        {
            //invia il messaggio a tutti i client nella Hub
            await Clients.All.SendAsync("ReceiveMessage",userName, message);
        }
    }
}
