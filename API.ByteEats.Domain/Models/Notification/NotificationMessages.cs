namespace API.ByteEats.Domain.Models.Notification;

public static class NotificationMessages
{
    public enum Type
    {
        NotFound
    }

    public static readonly Dictionary<Type, string> Messages = new()
    {
        { Type.NotFound, "{0} of ID '{1}' not found." }
    };
}