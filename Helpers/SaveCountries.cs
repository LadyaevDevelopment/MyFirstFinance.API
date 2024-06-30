using Data.Mock.Countries;
using Data.Production.Context;
using Data.Production.Repository.Countries;
using Microsoft.EntityFrameworkCore;

namespace Helpers
{
	internal class SaveCountries
	{
		public static async Task Process()
		{
			var dbContext = new DefaultDbContext(
				new DbContextOptionsBuilder<DefaultDbContext>()
					.UseSqlServer("data source=localhost; initial catalog=MyFirstFinance; Integrated security=True; TrustServerCertificate=True")
					.Options);
			var repository = new CountryRepository(dbContext);

			var repositoryMock = new CountryRepositoryMock();
			await repository.SavedEntities(await repositoryMock.FilteredEntities(new()));
		}
	}
}
