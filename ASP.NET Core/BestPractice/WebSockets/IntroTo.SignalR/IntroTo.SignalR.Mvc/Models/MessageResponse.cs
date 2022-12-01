namespace IntroTo.SignalR.Mvc.Models;

public struct MessageResponse
{
    public string Type { get; set; }
    public string? Text { get; set; }
    public int Receiver { get; set; }
}

public static class MessageType
{
    public const string Message = "message";
    public const string Notification = "notification";
}