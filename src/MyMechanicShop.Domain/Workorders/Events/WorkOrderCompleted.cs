using MyMechanicShop.Domain.Common;

namespace MyMechanicShop.Domain.Workorders.Events;

public sealed class WorkOrderCompleted : DomainEvent
{
    public Guid WorkOrderId { get; set; }
}