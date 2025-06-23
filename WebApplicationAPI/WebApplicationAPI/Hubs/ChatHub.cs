using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplicationAPI.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string senderName, string receiverId, string message)
        {
            // Send message to the specific user
            Clients.User(receiverId).receiveMessage(senderName, message);
        }

        public override Task OnConnected()
        {
            string userId = Context.QueryString["userId"];
            if (!string.IsNullOrEmpty(userId))
            {
                Groups.Add(Context.ConnectionId, userId);
            }
            return base.OnConnected();
        }
    }
}