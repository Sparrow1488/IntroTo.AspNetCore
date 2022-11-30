using Microsoft.AspNetCore.SignalR;

namespace IntroTo.SignalR.Mvc.Hubs;

public class ChatHub : Hub
{
    public async Task Send(string text, string userId)
    {
        if (int.TryParse(userId, out var validId) && string.IsNullOrWhiteSpace(text))
        {
            var response = GetMessageTemplate(validId, text);
            await Clients.All.SendAsync("Receive", response);
        }
        else
        {
            var caller = Clients.Caller;
            var response = GetMessageTemplate(101010, "System Response: Invalid UserId");
            await caller.SendAsync("Receive", response);
        }
    }

    private static string GetMessageTemplate(int sender, string message)
        => $"(id:{sender})msg: {message}";
}