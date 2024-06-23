using Domain.Entities.Users;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<User, UserSearchParams>
    {
    }
}
