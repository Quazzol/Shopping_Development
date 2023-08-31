using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Account.Domain;

public interface IUserRepository
{
   Task<Guid> Save(User user);
}
