namespace API.ByteEats.Domain.Enums;

/// <summary>
/// Status of the order. <br/>
/// 1: New <br/>
/// 2: Preparing <br/>
/// 3: Delivering <br/>
/// 4: Delivered
/// </summary>
public enum OrderStatus
{
    New = 1,
    Preparing = 2,
    Delivering = 3,
    Delivered = 4
}
