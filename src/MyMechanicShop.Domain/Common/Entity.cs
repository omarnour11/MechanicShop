namespace MyMechanicShop.Domain.Common;


public abstract class Entity
{
    
    public Guid Id {get;}

    private readonly List<DomainEvent> _domainEvents = [];
    protected  Entity(){}

    protected Entity(Guid id)
    {
        Id =id == Guid.Empty ? Guid.NewGuid() : id;
    }
    
    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void DeleteDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void ClearDomainEvent()
    {
       _domainEvents.Clear();
    }

}