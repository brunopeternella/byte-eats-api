using System.Text.Json.Serialization;
using API.ByteEats.Domain.Entities;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class UpdateUserCommand : IRequest<User>
{
    [JsonIgnore] public Guid Id { get; set; }

    public string? Name { get; set; }
}