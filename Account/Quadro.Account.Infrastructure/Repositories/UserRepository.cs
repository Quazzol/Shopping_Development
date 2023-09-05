using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quadro.Account.Domain;
using Quadro.Account.Infrastructure.DataModel;

namespace Quadro.Account.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountDbContext _accountDbContext;

        public UserRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<Guid> Save(User user)
        {
            //Mapping Logic
            var model = new UserDataModel();
            await _accountDbContext.Users.AddAsync(model);
            await _accountDbContext.SaveChangesAsync();
            return model.Id;
        }

        public Task<bool> UserNameTaken(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
