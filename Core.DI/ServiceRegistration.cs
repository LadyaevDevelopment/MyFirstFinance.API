using Core.SmsService;
using Data.Mock.Addresses;
using Data.Mock.Countries;
using Data.Mock.PolicyDocuments;
using Data.Mock.Users;
using Data.Production.Context;
using Domain.Repository;
using Domain.Services.CodeGeneration;
using Domain.Services.DateTimeNow;
using Domain.Services.SmsService;
using Domain.UseCases.RequireConfirmationCode;
using Domain.UseCases.SpecifyUserData.SpecifyBirthDate;
using Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument;
using Domain.UseCases.SpecifyUserInfo.SpecifyEmail;
using Domain.UseCases.SpecifyUserInfo.SpecifyIdentityDocument;
using Domain.UseCases.SpecifyUserInfo.SpecifyName;
using Domain.UseCases.SpecifyUserInfo.SpecifyPinCode;
using Domain.UseCases.SpecifyUserInfo.SpecifyResidenceAddress;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DI
{
	public static class ServiceRegistration
	{
		public static void Register(IServiceCollection services, ConfigurationManager configuration)
		{
			// repositories
			services.AddDbContext<DefaultDbContext>(
				options => options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					options => options.CommandTimeout(int.MaxValue)));
			services.AddScoped<IUserRepository, UserRepositoryMock>();
			services.AddScoped<ICountryRepository, CountryRepositoryMock>();
			services.AddScoped<IPolicyDocumentRepository, PolicyDocumentRepositoryMock>();
			services.AddScoped<IAddressRepository, AddressRepositoryMock>();

			// services
			services.AddScoped<CodeGeneration, CodeGeneration.Base>();
			services.AddScoped<DateTimeNow, DateTimeNow.Base>();
			services.AddScoped<ISmsService, SmsRuService>();

			// use cases
			services.AddSingleton<RequireConfirmationCodeUseCase>();
			services.AddSingleton<SkipProvisioningIdentityDocumentUseCase>();
			services.AddSingleton<SpecifyBirthDateUseCase>();
			services.AddSingleton<SpecifyEmailUseCase>();
			services.AddSingleton<SpecifyIdentityDocumentUseCase>();
			services.AddSingleton<SpecifyNameUseCase>();
			services.AddSingleton<SpecifyPinCodeUseCase>();
			services.AddSingleton<SpecifyResidenceAddressUseCase>();
		}
	}
}
