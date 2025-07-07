using System;
using System.Collections.Generic;

namespace MyDddProject.Domain.Common;

/// <summary>
/// Base entity class with common properties
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Entity unique identifier
    /// </summary>
    public virtual int Id { get; set; }

    /// <summary>
    /// When the entity was created
    /// </summary>
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When the entity was last updated
    /// </summary>
    public virtual DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Who created the entity
    /// </summary>
    public virtual string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// Who last updated the entity
    /// </summary>
    public virtual string? UpdatedBy { get; set; }

    /// <summary>
    /// Domain events for this entity
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Get domain events
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Add domain event
    /// </summary>
    /// <param name="domainEvent">Domain event to add</param>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clear domain events
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
