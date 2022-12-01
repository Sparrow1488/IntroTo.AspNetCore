using IntroTo.SignalR.Mvc.Models;
using IntroTo.SignalR.Mvc.Services;
using Microsoft.AspNetCore.SignalR;

namespace IntroTo.SignalR.Mvc.Hubs;

public class ChatHub : Hub
{
    private readonly UserManager _manager;

    public ChatHub(UserManager manager)
    {
        _manager = manager;
    }
    
    [HubMethodName("Send")]
    public async Task SendAsync(MessageRequest message, string userId)
    {
        var user = Clients.User("1");
        await Groups.AddToGroupAsync(Context.ConnectionId, "group");
        
        var authorizedUser = _manager.GetUser(int.Parse(userId));
        if (authorizedUser is not null && !string.IsNullOrWhiteSpace(message.Text))
        {
            var response = GetMessageTemplate(authorizedUser.Id, message.Text);
            await Clients.All.SendCoreAsync("Receive", new object?[] { response });
            return;
        }
        await WriteErrorAsync("[System] O-ops");
    }

    private static MessageResponse GetMessageTemplate(int sender, string message)
    {
        return new MessageResponse
        {
            Text = $"({sender}) {message}",
            Type = MessageType.Message
        };
    }

    private async Task WriteErrorAsync(string error)
    {
        var caller = Clients.Caller;
        var response = GetMessageTemplate(-1, error);
        await caller.SendAsync("Receive", response);
    }
}