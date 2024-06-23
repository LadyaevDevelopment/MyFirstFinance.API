using Domain.Entities.PolicyDocuments;
using Domain.Repository;

namespace Data.Mock.PolicyDocuments
{
    public class PolicyDocumentRepositoryMock : IPolicyDocumentRepository
	{
		private readonly static PolicyDocument[] Data = 
		[
			new PolicyDocument(
				Guid.NewGuid(),
				"Privacy Policy",
				"https://business-platform.ru/reg-permission.pdf?ysclid=lxrf9oym18928564996"),
			new PolicyDocument(
				Guid.NewGuid(),
				"Esign Consent",
				"https://business-platform.ru/reg-permission.pdf?ysclid=lxrf9oym18928564996"),
			new PolicyDocument(
				Guid.NewGuid(),
				"Communication Policy",
				"https://business-platform.ru/reg-permission.pdf?ysclid=lxrf9oym18928564996"),
		];

		public Task<PolicyDocument?> EntityById(Guid id)
		{
			return Task.FromResult((PolicyDocument?)Data.First());
		}

		public Task<List<PolicyDocument>> FilteredEntities(object searchParams)
		{
			return Task.FromResult(Data.ToList());
		}

		public Task<bool> RemoveByFilter(object searchParams)
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

		public Task<List<PolicyDocument>> SavedEntities(List<PolicyDocument> entitiesToSave)
		{
			return Task.FromResult(entitiesToSave);
		}

		public Task<PolicyDocument> SavedEntity(PolicyDocument entityToSave)
		{
			return Task.FromResult(entityToSave);
		}
	}
}
