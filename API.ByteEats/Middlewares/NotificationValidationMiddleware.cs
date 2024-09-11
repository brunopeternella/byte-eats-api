using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;

namespace API.ByteEats.Middlewares;

public class NotificationValidationMiddleware
{
    private readonly RequestDelegate _next;

    public NotificationValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, INotificationService notificationService)
    {
        await _next(context);

        var notifications = notificationService.GetNotifications();
        if (notifications.Count > 0)
        {

            if(context.Response.StatusCode != StatusCodes.Status400BadRequest)
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Response.ContentType = "application/json";

            var response =
                new NotificationResponseModel(StatusCodes.Status400BadRequest, notifications);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
