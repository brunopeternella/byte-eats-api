namespace API.ByteEats.Domain.Models.Notification;

public class NotificationModel
{
    /// <summary>
    /// Type of the error.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    public string Message { get; set; }
}
