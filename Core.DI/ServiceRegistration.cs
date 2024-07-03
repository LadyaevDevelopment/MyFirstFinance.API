using Core.Common.Authentication;
using Core.Common.DateTimeNow;
using Core.Common.Email;
using Core.Common.FileService;
using Core.Common.PhoneNumber;
using Core.Common.Random;
using Core.Common.SmsService;
using Core.Common.TokenGenerator;
using Data.Mock.Addresses;
using Data.Mock.PolicyDocuments;
using Data.Production.Context;
using Data.Production.Repository.ConfirmationCodes;
using Data.Production.Repository.Countries;
using Data.Production.Repository.Users;
using Domain.Entities.Misc;
using Domain.Repository;
using Domain.UseCases.RequireConfirmationCode;
using Domain.UseCases.SpecifyUserData.SpecifyBirthDate;
using Domain.UseCases.SpecifyUserInfo.Base;
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
			services.AddDbContext<DefaultDbContext>(
				options => options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					options => options.CommandTimeout(int.MaxValue)));
			services.AddSingleton(_ => new Configuration(
				ConfirmationCodeLength: 6,
				ConfirmationCodeLifeTimeInSeconds: 300,
				UserTemporaryBlockingTimeInSeconds: 600,
				AllowedFailedCodeConfirmationAttemptCount: 3,
				ResendConfirmationCodeTimeInSeconds: 120,
				MinUserAge: 18,
				PinCodeLength: 4,
				UploadsDirectoryPath: "uploads"));

			// repositories
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<IPolicyDocumentRepository, PolicyDocumentRepositoryMock>();
			services.AddScoped<IAddressRepository, AddressRepositoryMock>();
			services.AddScoped<IConfirmationCodeRepository, ConfirmationCodeRepository>();

			// services
			//services.AddScoped<IRandom, IRandom.Base>();
			services.AddScoped<IRandom>(_ => new IRandom.Static(123456, "123456"));
			services.AddScoped<IDateTimeNow, IDateTimeNow.Base>();
			services.AddScoped<ISmsService, SmsServiceMock>();
			services.AddScoped<IFileService, IFileService.Base>();
			services.AddScoped<IEmailValidation, IEmailValidation.Base>();
			services.AddScoped<IPhoneNumberValidation, IPhoneNumberValidation.Base>();
			services.AddScoped<ITokenGenerator>(_ => new ITokenGenerator.Base(
				new AesCryptoServiceProvider(),
				"Frh!zp0IqSz2KxkV",
				"KOcg!Eo*",
				60L * 60 * 24 * 365,
				null));
			services.AddScoped<ITokenProcessor, ITokenProcessor.Base>();

			// use cases
			services.AddScoped<ProvisioningUserData, ProvisioningUserData.Base>();
			services.AddScoped<RequireConfirmationCodeUseCase>();
			services.AddScoped<VerifyConfirmationCodeUseCase>();
			services.AddScoped<SkipProvisioningIdentityDocumentUseCase>();
			services.AddScoped<SpecifyBirthDateUseCase>();
			services.AddScoped<SpecifyEmailUseCase>();
			services.AddScoped<SpecifyIdentityDocumentUseCase>();
			services.AddScoped<SpecifyNameUseCase>();
			services.AddScoped<SpecifyPinCodeUseCase>();
			services.AddScoped<SpecifyResidenceAddressUseCase>();
		}
	}
}
