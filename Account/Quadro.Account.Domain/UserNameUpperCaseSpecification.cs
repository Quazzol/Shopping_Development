using System.Linq.Expressions;
using Quadro.Core.Domain.Validation;

namespace Quadro.Account.Domain
{
    public class UserNameUpperCaseSpecification : Specification<User>
    {
        public override Expression<Func<User, bool>> Expression => user => user.Name.All(char.IsUpper);
    }
}
