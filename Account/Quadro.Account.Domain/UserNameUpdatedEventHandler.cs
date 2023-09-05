using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain
{
    public class UserNameUpdatedEventHandler : IDomainEventHandler<UserNameUpdated>
    {
        public IUserRepository Repository { get; }

        public UserNameUpdatedEventHandler(IUserRepository repository)
        {
            Repository = repository;
        }

        public async void Handle(UserNameUpdated domainEvent)
        {

            var userNameTaken = await Repository.UserNameTaken(domainEvent.Name);
            if (userNameTaken)
            {
                throw new Exception("UserName Already taken!");
            }
        }
    }
}
