using Core.Common.Authentication;
using Core.Common.DateTimeNow;
using Core.Common.Email;
using Core.Common.FileService;
using Core.Common.PhoneNumber;
using Core.Common.Random;
using Core.Common.SmsService;
using Core.Common.TokenGenerator;
using Data.Mock.Addresses;
using Data.Mock.Countries;
using Data.Mock.PolicyDocuments;
using Data.Mock.Users;
using Data.Production.Context;
using Domain.Repository;
using Domain.UseCases.RequireConfirmationCode;
using Domain.UseCases.SpecifyUserData.SpecifyBirthDate;
using Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument;
using Domain.UseCases.SpecifyUserInfo.SpecifyEmail;
using Domain.UseCases.SpecifyUserInfo.SpecifyIdentityDocument;
using Domain.UseCases.SpecifyUserInfo.SpecifyName;
using Domain.UseCases.SpecifyUserInfo.SpecifyPinCode;
using Domain.UseCases.SpecifyUserInfo.SpecifyResidenceAddress;
using Domain.UseCases.VerifyConfirmationCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

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
			services.AddScoped<IRandom, IRandom.Base>();
			services.AddScoped<IDateTimeNow, IDateTimeNow.Base>();
			services.AddScoped<ISmsService, SmsServiceMock>();
			services.AddScoped<IFileService, IFileService.Base>();
			services.AddScoped<IEmailValidation, IEmailValidation.Base>();
			services.AddScoped<IPhoneNumberValidation, IPhoneNumberValidation.Base>();
			services.AddSingleton<ITokenGenerator>(_ => new ITokenGenerator.Base(
				new AesCryptoServiceProvider(),
				"Frh!zp0IqSz2KxkV",
				"KOcg!Eo*",
				60L * 60 * 24 * 365,
				null));
			services.AddScoped<ITokenProcessor, ITokenProcessor.Base>();

			// use cases
			services.AddSingleton<RequireConfirmationCodeUseCase>();
			services.AddSingleton<VerifyConfirmationCodeUseCase>();
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
