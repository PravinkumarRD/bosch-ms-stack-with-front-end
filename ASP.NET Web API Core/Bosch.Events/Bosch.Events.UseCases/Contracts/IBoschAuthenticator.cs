using Bosch.Events.Domain.Entities;

namespace Bosch.Events.UseCases.Contracts
{
    public interface IBoschAuthenticator
    {
        Task<User> Authenticate(User user);
    }
}
