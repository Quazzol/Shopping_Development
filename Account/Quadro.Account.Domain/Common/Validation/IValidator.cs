namespace Quadro.Account.Domain.Common.Validation;

public interface IValidator<in T>
{
    ValidationResult Validate(T entity);

}
