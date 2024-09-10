using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Models.Notification;

namespace API.ByteEats.Domain.Services;

public class NotificationService : INotificationService
{
    private readonly List<NotificationModel> _notifications;

    public NotificationService()
    {
        _notifications = new List<NotificationModel>();
    }

    public void AddNotification(NotificationMessages.Type type, params string[] arguments)
    {
        if (!NotificationMessages.Messages.TryGetValue(type, out var messageTemplate)) return;

        var message = string.Format(messageTemplate, arguments);

        _notifications.Add(new NotificationModel
        {
            Type = Enum.GetName(typeof(NotificationMessages.Type), type),
            Message = message
        });
    }

    public IReadOnlyList<NotificationModel> GetNotifications()
    {
        return _notifications.AsReadOnly();
    }

    public bool HasNotifications()
    {
        return _notifications.Count != 0;
    }
}
