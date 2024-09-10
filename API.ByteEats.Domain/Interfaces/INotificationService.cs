using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;

namespace API.ByteEats.Domain.Interfaces;

public interface INotificationService
{
    void AddNotification(NotificationMessages.Type type, params string[] arguments);
    IReadOnlyList<NotificationModel> GetNotifications();
    bool HasNotifications();
}