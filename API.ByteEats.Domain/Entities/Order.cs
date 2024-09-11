namespace API.ByteEats.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public bool WasPaid { get; set; }

    public virtual User User { get; set; }
}
