using API.ByteEats.Domain.Entities;

namespace API.ByteEats.Domain.Models.UserCommands;

public class GetUsersQuery : PagedQuery<User>
{
}