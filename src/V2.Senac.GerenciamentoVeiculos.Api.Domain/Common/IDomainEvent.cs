using System;

namespace MyDddProject.Domain.Common;

/// <summary>
/// Domain event interface
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// When the event occurred
    /// </summary>
    DateTime OccurredOn { get; }
}
