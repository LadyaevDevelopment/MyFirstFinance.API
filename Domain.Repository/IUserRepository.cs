using Domain.Entities.Users;

namespace Domain.Repository
{
	public interface IUserRepository : IRepository<User, UserSearchParams>
    {
        Task<UserTemporaryBan> SavedTemporaryBan(UserTemporaryBan item);

        Task<bool> RemoveBanById(Guid id);
    }
}
