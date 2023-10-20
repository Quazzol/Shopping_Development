using System.ComponentModel.DataAnnotations;

namespace Quadro.Core.Domain.SeedWork;
public abstract class Entity<TKey> : IEntity<TKey>
{
    public TKey? Id { get; init; }

    public virtual object Clone() => MemberwiseClone();
}
 