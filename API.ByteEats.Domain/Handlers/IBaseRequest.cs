using API.ByteEats.Domain.Models;
using MediatR;

namespace API.ByteEats.Domain.Handlers;

public interface IBaseRequest<TResponse> : IRequest<Result<TResponse>>
{ }
