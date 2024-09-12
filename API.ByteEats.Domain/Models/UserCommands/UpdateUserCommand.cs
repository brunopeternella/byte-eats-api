using System.Text.Json.Serialization;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class UpdateUserCommand : IBaseRequest<User>
{
    [JsonIgnore] public Guid Id { get; set; }

    /// <summary>
    /// User name.
    /// </summary>
    public string? Name { get; set; }
}
