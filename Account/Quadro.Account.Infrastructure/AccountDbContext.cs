using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quadro.Account.Infrastructure.DataModel;

namespace Quadro.Account.Infrastructure
{
    public class AccountDbContext: DbContext
    {
        public DbSet<UserDataModel> Users { get; set; }

    }
}
