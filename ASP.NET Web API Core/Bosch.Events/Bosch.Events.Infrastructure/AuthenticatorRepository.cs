using Bosch.Events.Dal;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bosch.Events.Infrastructure
{
    public class AuthenticatorRepository : IBoschAuthenticator
    {
        private readonly BoschEventsDbContext _dbContext;

        public AuthenticatorRepository(BoschEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Authenticate(User user)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => user.UserName == u.UserName);
        }
    }
}
