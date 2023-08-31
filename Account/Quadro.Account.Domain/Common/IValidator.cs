namespace Quadro.Account.Domain.Common;

    public interface IValidator<in T>
    {
        bool IsValid(T entity);

        IEnumerable<string> BrokenRules(T entity);
    }
