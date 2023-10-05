namespace Quadro.Core.Domain.Validation;

public class ValidationResult
{
    private readonly List<ValidationError> _errors = new();

    public bool IsValid => _errors.Count == 0;

    public IEnumerable<ValidationError> Errors => _errors;

    public void AddError(ValidationError error)
    {
        _errors.Add(error);
    }

    public void RemoveError(ValidationError error)
    {
        if (_errors.Contains(error))
            _errors.Remove(error);
    }

    public void Combine(ValidationResult result)
    {
        foreach (var validationError in result.Errors)
        {
            AddError(validationError);
        }
    }
}

