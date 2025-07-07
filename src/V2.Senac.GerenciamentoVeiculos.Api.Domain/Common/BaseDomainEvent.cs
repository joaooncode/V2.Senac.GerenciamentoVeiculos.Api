using System;

namespace MyDddProject.Domain.Common;

/// <summary>
/// Base domain event implementation
/// </summary>
public abstract class BaseDomainEvent : IDomainEvent
{
    /// <summary>
    /// When the event occurred
    /// </summary>
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
