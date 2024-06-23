using Domain.Entities.Users;
using Domain.Repository;

namespace Data.Mock.Users
{
    public class UserRepositoryMock : IUserRepository
    {
        private readonly static User Entity = new(
            Guid.NewGuid(),
            "LastName",
            "FirstName",
            null,
            "PhoneNumber",
            "Email",
            null,
            false,
            UserStatus.Registered);

        public Task<User?> EntityById(Guid id)
        {
            return Task.FromResult((User?)Entity);
        }

        public Task<List<User>> FilteredEntities(UserSearchParams searchParams)
        {
            return Task.FromResult(new List<User> { Entity });
        }

        public Task<bool> RemoveByFilter(UserSearchParams searchParams)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RemoveById(Guid id)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RemoveById(List<Guid> ids)
        {
            return Task.FromResult(true);
        }

        public Task<List<User>> SavedEntities(List<User> entitiesToSave)
        {
            return Task.FromResult(entitiesToSave);
        }

        public Task<User> SavedEntity(User entityToSave)
        {
            return Task.FromResult(entityToSave);
        }
    }
}
