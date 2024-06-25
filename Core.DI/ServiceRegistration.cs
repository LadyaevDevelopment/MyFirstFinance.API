using Data.Mock.Addresses;
using Data.Mock.Countries;
using Data.Mock.PolicyDocuments;
using Data.Mock.Users;
using Data.Production.Context;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DI
{
	public static class ServiceRegistration
	{
		public static void Register(IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddDbContext<DefaultDbContext>(
				options => options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					options => options.CommandTimeout(int.MaxValue)));
			services.AddScoped<IUserRepository, UserRepositoryMock>();
			services.AddScoped<ICountryRepository, CountryRepositoryMock>();
			services.AddScoped<IPolicyDocumentRepository, PolicyDocumentRepositoryMock>();
			services.AddScoped<IAddressRepository, AddressRepositoryMock>();
		}
	}
}
