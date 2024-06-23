using Domain.Entities.Countries;
using Domain.Repository;

namespace Data.Mock.Countries
{
    public class CountryRepositoryMock : ICountryRepository
    {
        public Task<Country?> EntityById(Guid id)
        {
            return Task.FromResult((Country?)CountrySource.Data.First());
		}

        public Task<List<Country>> FilteredEntities(object searchParams)
        {
            return Task.FromResult(CountrySource.Data.ToList());
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

        public Task<List<Country>> SavedEntities(List<Country> entitiesToSave)
        {
            return Task.FromResult(entitiesToSave);
        }

        public Task<Country> SavedEntity(Country entityToSave)
        {
            return Task.FromResult(entityToSave);
        }
    }
}
