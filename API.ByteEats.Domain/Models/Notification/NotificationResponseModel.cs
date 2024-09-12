namespace API.ByteEats.Domain.Models.Notification;

public class NotificationResponseModel
{
    public NotificationResponseModel(int status, IReadOnlyList<NotificationModel> notifications)
    {
        Status = status;
        Notifications = notifications;
    }

    public string Type { get; } = "https://tools.ietf.org/html/rfc9110#section-15.5.1";
    public string Title { get; } = "One or more validation errors occurred.";
    public int Status { get; }
    public IReadOnlyList<NotificationModel> Notifications { get; }
}
