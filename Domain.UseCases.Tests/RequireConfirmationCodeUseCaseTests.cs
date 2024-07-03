using Core.Common.DateTimeNow;
using Core.Common.PhoneNumber;
using Core.Common.Random;
using Core.Common.SmsService;
using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.ConfirmationCodes;
using Data.Production.Repository.Countries;
using Data.Production.Repository.Users;
using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Countries;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.UseCases.RequireConfirmationCode;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Domain.UseCases.Tests
{
	public class RequireConfirmationCodeUseCaseTests
	{
		private readonly DefaultDbContext _context;
		private readonly UserRepository _userRepository;
		private readonly ConfirmationCodeRepository _confirmationCodeRepository;
		private readonly CountryRepository _countryRepository;

		private readonly Mock<ISmsService> _smsServiceMock;
		private readonly Mock<IPhoneNumberValidation> _phoneNumberValidation;
		private readonly Mock<IRandom> _randomMock;
		private readonly Mock<IDateTimeNow> _dateTimeNowMock;
		private readonly Configuration _configuration;
		private readonly RequireConfirmationCodeUseCase _useCase;

		public RequireConfirmationCodeUseCaseTests()
		{
			var options = new DbContextOptionsBuilder<DefaultDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			_context = new DefaultDbContext(options);
			_userRepository = new UserRepository(_context);
			_confirmationCodeRepository = new ConfirmationCodeRepository(_context);
			_countryRepository = new CountryRepository(_context);

			_smsServiceMock = new Mock<ISmsService>();
			_phoneNumberValidation = new Mock<IPhoneNumberValidation>();

			_randomMock = new Mock<IRandom>();
			_dateTimeNowMock = new Mock<IDateTimeNow>();
			_dateTimeNowMock.Setup(dateTime => dateTime.Now)
				.Returns(DateTimeOffset.UtcNow);

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

			_useCase = new RequireConfirmationCodeUseCase(
				_smsServiceMock.Object,
				_randomMock.Object,
				_confirmationCodeRepository,
				_userRepository,
				_countryRepository,
				_dateTimeNowMock.Object,
				_phoneNumberValidation.Object,
				_configuration);
		}

		[Fact]
		public async Task Process_UserBlocked_ReturnsFailure()
		{
			// Arrange
			var phoneNumberCode = "+598";
			var phoneNumber = "1-111-11-11";
			var fullPhoneNumber = phoneNumberCode + " " + phoneNumber;
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: fullPhoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: true,
				RegistrationDate: _dateTimeNowMock.Object.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			_phoneNumberValidation
				.Setup(service => service.ValidPhoneNumberOrNull(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Country>>()))
				.Returns<string, string, List<Country>>((phoneNumberCode, phoneNumber, countries) =>
				{
					return phoneNumberCode + " " + phoneNumber;
				});

			// Act
			var result = await _useCase.Process(phoneNumberCode, phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.UserBlocked, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_UserTemporarilyBlocked_ReturnsFailure()
		{
			// Arrange
			var phoneNumberCode = "+44";
			var phoneNumber = "11-1111-1111";
			var fullPhoneNumber = phoneNumberCode + " " + phoneNumber;
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: fullPhoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTimeOffset.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);
			
			var userTemporaryBan = new UserTemporaryBan(
				Guid.NewGuid(),
				user.Id,
				_dateTimeNowMock.Object.Now.AddSeconds(-300),
				400);

			_context.Users.Add(user.ToModel());
			_context.UserTemporaryBans.Add(userTemporaryBan.ToModel());
			await _context.SaveChangesAsync();

			_phoneNumberValidation
				.Setup(service => service.ValidPhoneNumberOrNull(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Country>>()))
				.Returns<string, string, List<Country>>((phoneNumberCode, phoneNumber, countries) =>
				{
					return phoneNumberCode + " " + phoneNumber;
				});

			// Act
			var result = await _useCase.Process(phoneNumberCode, phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.UserTemporaryBlocked, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ConfirmationCodeAlreadySent_ReturnsFailure()
		{
			// Arrange
			var phoneNumberCode = "+376";
			var phoneNumber = "111-111";
			var fullPhoneNumber = phoneNumberCode + " " + phoneNumber;
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: fullPhoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: _dateTimeNowMock.Object.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);
			
			var activeConfirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 0);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(activeConfirmationCode.ToModel());
			await _context.SaveChangesAsync();

			_phoneNumberValidation
				.Setup(service => service.ValidPhoneNumberOrNull(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Country>>()))
				.Returns<string, string, List<Country>>((phoneNumberCode, phoneNumber, countries) =>
				{
					return phoneNumberCode + " " + phoneNumber;
				});

			// Act
			var result = await _useCase.Process(phoneNumberCode, phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.ConfirmationCodeAlreadySent, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_SmsServiceFails_ReturnsFailure()
		{
			// Arrange
			var phoneNumberCode = "+672";
			var phoneNumber = "311-111";
			var fullPhoneNumber = phoneNumberCode + " " + phoneNumber;

			_smsServiceMock
				.Setup(service => service.SendSmsMessage(It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync(new SendSmsMessageResult.Failure(new Exception("Sms service error")));

			_phoneNumberValidation
				.Setup(service => service.ValidPhoneNumberOrNull(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Country>>()))
				.Returns<string, string, List<Country>>((phoneNumberCode, phoneNumber, countries) =>
				{
					return phoneNumberCode + " " + phoneNumber;
				});

			// Act
			var result = await _useCase.Process(phoneNumberCode, phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.Other, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_Successful_ReturnsSuccess()
		{
			// Arrange
			var phoneNumberCode = "+49";
			var phoneNumber = "111-111";
			var fullPhoneNumber = phoneNumberCode + " " + phoneNumber;

			var digitalCode = int.Parse("1" + new string(Enumerable.Repeat('0', _configuration.ConfirmationCodeLength - 1).ToArray()));
			_randomMock.Setup(r => r.RandomInt(_configuration.ConfirmationCodeLength)).Returns(digitalCode);

			_phoneNumberValidation
				.Setup(service => service.ValidPhoneNumberOrNull(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Country>>()))
				.Returns<string, string, List<Country>>((phoneNumberCode, phoneNumber, countries) =>
				{
					return phoneNumberCode + " " + phoneNumber;
				});

			_smsServiceMock
				.Setup(service => service.SendSmsMessage(
					It.IsAny<string>(),
					It.IsAny<string>()))
				.ReturnsAsync(new SendSmsMessageResult.Success());

			// Act
			var result = await _useCase.Process(phoneNumberCode, phoneNumber);

			// Assert
			Assert.True(result.Successful);
			Assert.NotNull(result.Data);
			Assert.Null(result.Error);
			Assert.Equal(_configuration.ConfirmationCodeLength, result.Data.ConfirmationCodeLength);
			Assert.Equal(_configuration.ResendConfirmationCodeTimeInSeconds, result.Data.ResendTimeInSeconds);
			Assert.Equal(_configuration.AllowedFailedCodeConfirmationAttemptCount, result.Data.AllowedConfirmCodeAttemptCount);
			Assert.Equal(_configuration.ConfirmationCodeLifeTimeInSeconds, result.Data.ConfirmationCodeLifeTimeInSeconds);
		}
	}
}
