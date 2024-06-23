using Domain.Entities.Addresses;
using Domain.Repository;

namespace Data.Mock.Addresses
{
	public class AddressRepositoryMock : IAddressRepository
	{
		public Task<Address?> EntityById(Guid id)
		{
			return Task.FromResult((Address?)null);
		}

		public Task<List<Address>> FilteredEntities(AddressSearchParams searchParams)
		{
			return Task.FromResult(new List<Address>());
		}

		public Task<bool> RemoveByFilter(AddressSearchParams searchParams)
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

		public Task<List<Address>> SavedEntities(List<Address> entitiesToSave)
		{
			return Task.FromResult(entitiesToSave);
		}

		public Task<Address> SavedEntity(Address entityToSave)
		{
			return Task.FromResult(entityToSave);
		}
	}
}
