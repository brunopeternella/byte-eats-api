namespace API.ByteEats.Domain.Models;

public class Result<T>
{
    public T Value { get; private set; } = default!;
    public bool IsSuccess { get; private set; }

    public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
    public static Result<T> Failure() => new Result<T> { IsSuccess = false };
}
