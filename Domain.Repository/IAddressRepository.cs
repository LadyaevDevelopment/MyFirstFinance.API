using Domain.Entities.Addresses;

namespace Domain.Repository
{
	public interface IAddressRepository : IRepository<Address, AddressSearchParams>
	{
	}
}
