namespace Quadro.Core.Domain.Validation;

public abstract class CompositeValidator<T> : IValidator<T>
{
    private readonly List<IValidator<T>> _validators = new();

    protected CompositeValidator()
    {
    }

    public void AddValidator(params IValidator<T>[] validator)
    {
        _validators.AddRange(validator);
    }

    public void RemoveValidator(IValidator<T> validator)
    {
        _validators.Remove(validator);
    }

    public ValidationResult Validate(T entity)
    {
        var result = new ValidationResult();
        foreach (var validator in _validators)
        {
            result.Combine(validator.Validate(entity));
        }
        return result;
    }

}

