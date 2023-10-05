namespace Quadro.Core.Domain.SeedWork;

/// <summary>
/// General abstraction for entities
/// </summary>
public interface IEntity
{ }

/// <summary>
/// General abstraction for entities
/// </summary>
/// <typeparam name="T">Entity Id Type </typeparam>
public interface IEntity<T> : IEntity
{
    public T Id { get; init; }
}
