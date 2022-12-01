namespace IntroTo.SignalR.Mvc.Models;

public struct MessageRequest
{
    public string? Text { get; set; }
    public int Receiver { get; set; }
}