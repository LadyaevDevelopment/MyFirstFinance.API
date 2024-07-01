using Domain.Entities.Users;

namespace Domain.Repository
{
	public interface IUserRepository : IRepository<User, UserSearchParams>
    {
        Task<UserTemporaryBan> SavedTemporaryBan(UserTemporaryBan itemToSave);

        Task<bool> RemoveTemporaryBanById(Guid id);

		Task<UserResidenceAddress> SavedResidenceAddress(UserResidenceAddress itemToSave);

		Task<bool> RemoveResidenceAddressById(Guid id);

		Task<IdentityDocument?> IdentityDocument(Guid userId);

		Task<IdentityDocument> SavedIdentityDocument(IdentityDocument itemToSave);

		Task<bool> RemoveIdentityDocumentById(Guid id);
	}
}
