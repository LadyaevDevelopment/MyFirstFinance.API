﻿using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.Countries;
using Data.Production.Repository.Users;
using Domain.Entities.Countries;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.UseCases.SpecifyUserInfo.Base;
using Domain.UseCases.SpecifyUserInfo.SpecifyResidenceAddress;
using Microsoft.EntityFrameworkCore;

namespace Domain.UseCases.Tests
{
	public class SpecifyResidenceAddressUseCaseTests
	{
		private readonly DefaultDbContext _context;
		private readonly UserRepository _userRepository;
		private readonly CountryRepository _countryRepository;

		private readonly Configuration _configuration;
		private readonly SpecifyResidenceAddressUseCase _useCase;
		private readonly UserStatusStrategy _provisioningUserData;

		public SpecifyResidenceAddressUseCaseTests()
		{
			var options = new DbContextOptionsBuilder<DefaultDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			_context = new DefaultDbContext(options);
			_userRepository = new UserRepository(_context);
			_countryRepository = new CountryRepository(_context);

			_provisioningUserData = new UserStatusStrategy.Base();

			_configuration = new Configuration(
				ConfirmationCodeLength: 6,
				ConfirmationCodeLifeTimeInSeconds: 300,
				UserTemporaryBlockingTimeInSeconds: 600,
				AllowedFailedCodeConfirmationAttemptCount: 3,
				ResendConfirmationCodeTimeInSeconds: 120,
				MinUserAge: 18,
				PinCodeLength: 4,
				UploadsDirectoryPath: "uploads"
			);

			_useCase = new SpecifyResidenceAddressUseCase(
				_userRepository,
				_provisioningUserData,
				_configuration);
		}

		[Fact]
		public async Task Process_ReturnsSuccess()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+968 9411-11-11",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTimeOffset.Now,
				Status: UserStatus.NeedToSpecifyResidenceAddress);
			
			var country = new Country(
				Id: Guid.NewGuid(),
				Name: "Test",
				Iso2Code: "TE",
				PhoneNumberCode: "+968",
				FlagImageUrl: "Url",
				PhoneNumberMasks: []
			);

			_context.Users.Add(user.ToModel());
			_context.Countries.Add(country.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id, country.Id, "city", "street", "buildingNumber", "apartmentNumber");

			// Assert
			Assert.True(result.Successful);
			Assert.NotNull(result.Data);
		}
	}
}
