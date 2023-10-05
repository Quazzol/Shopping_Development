using System.Linq.Expressions;

namespace Quadro.Core.Domain.Validation;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> Expression { get; }
    public bool IsSatisfiedBy(T entity);
}