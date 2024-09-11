using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

[Route("api/byte-eats/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    protected IMediator Mediator { get; private set; }

    public ApiController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [NonAction]
    public ObjectResult BadRequestNotification()
        => new ObjectResult(null){ StatusCode = 400};
}
