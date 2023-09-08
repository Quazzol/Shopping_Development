using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain
{
    public class UserNameUpperCaseSpecification : Specification<User>
    {
        public override Expression<Func<User, bool>> Expression => user => user.Name.All(char.IsUpper);
    }
}
