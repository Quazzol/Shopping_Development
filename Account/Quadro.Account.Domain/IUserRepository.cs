using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Account.Domain;

public interface IUserRepository
{
   Task<Guid> SignUpUser(User user, CancellationToken cancellationToken = default);

   Task SignInUser(User user, CancellationToken cancellationToken = default);

}
