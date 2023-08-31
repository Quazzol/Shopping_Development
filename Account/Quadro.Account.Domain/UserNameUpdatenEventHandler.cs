using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain
{
    public class UserNameUpdatenEventHandler : IDomainEventHandler<UserNameUpdated>
    {
        public IUserRepository Repository { get; }

        public UserNameUpdatenEventHandler(IUserRepository repository)
        {
            Repository = repository;
        }

        public void Handle(UserNameUpdated domainEvent)
        {

           
        }
    }
}
