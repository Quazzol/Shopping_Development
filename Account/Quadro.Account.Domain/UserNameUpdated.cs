using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Account.Domain.Common;

namespace Quadro.Account.Domain
{
    public class UserNameUpdated : IDomainEvent
    {
        public string Name { get; set; }
    }
}
