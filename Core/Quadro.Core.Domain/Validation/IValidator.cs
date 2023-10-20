namespace Quadro.Core.Domain.Validation;

public interface IValidator<in T>
{
    ValidationResult Validate(T entity);

}
