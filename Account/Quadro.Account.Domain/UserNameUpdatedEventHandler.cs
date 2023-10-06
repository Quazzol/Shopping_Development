using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Core.Domain.EventBus;

namespace Quadro.Account.Domain
{
    public class UserNameUpdatedEventHandler : IEventHandler<UserNameUpdated>
    {
        public IUserRepository Repository { get; }

        public UserNameUpdatedEventHandler(IUserRepository repository)
        {
            Repository = repository;
        }
 

        public async Task Handle(UserNameUpdated @event, CancellationToken cancellationToken)
        {
            var userNameTaken = await Repository.UserNameTaken(@event.Name);
            if (userNameTaken)
            {
                throw new Exception("UserName Already taken!");
    }
}
    }
}
