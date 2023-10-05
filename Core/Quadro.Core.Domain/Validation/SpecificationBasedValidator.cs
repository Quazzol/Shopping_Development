using Ardalis.GuardClauses;

namespace Quadro.Core.Domain.Validation;

public abstract class SpecificationBasedValidator<T> : IValidator<T>
{
    public ISpecification<T> Specification { get; }

    protected SpecificationBasedValidator(ISpecification<T> specification)
    {
        Guard.Against.Null(specification, nameof(specification));
        Specification = specification;
    }

    public ValidationResult Validate(T entity)
    {
        var validationResult = new ValidationResult();
        if (!Specification.IsSatisfiedBy(entity))
        {
            validationResult.AddError(GetError(entity));
        }
        return validationResult;
    }

    protected abstract ValidationError GetError(T entity);
}

