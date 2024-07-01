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
            DateOnly.FromDateTime(DateTime.Now),
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

		public Task<bool> RemoveTemporaryBanById(Guid id)
		{
			return Task.FromResult(true);
		}

		public Task<UserTemporaryBan> SavedTemporaryBan(UserTemporaryBan itemToSave)
		{
			return Task.FromResult(itemToSave);
		}

		public Task<UserResidenceAddress> SavedResidenceAddress(UserResidenceAddress itemToSave)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveResidenceAddressById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityDocument> SavedIdentityDocument(IdentityDocument itemToSave)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveIdentityDocumentById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityDocument?> IdentityDocument(Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
