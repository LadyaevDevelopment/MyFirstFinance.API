using Core.Common.DateTimeNow;
using Core.Common.Random;
using Core.Common.SmsService;
using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.ConfirmationCodes;
using Data.Production.Repository.Users;
using Domain.Entities.ConfirmationCodes;
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

		private readonly Mock<ISmsService> _smsServiceMock;
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

			_smsServiceMock = new Mock<ISmsService>();

			_randomMock = new Mock<IRandom>();
			_dateTimeNowMock = new Mock<IDateTimeNow>();
			_dateTimeNowMock.Setup(dateTime => dateTime.Now)
				.Returns(DateTime.UtcNow);

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
				_dateTimeNowMock.Object,
				_configuration);
		}

		[Fact]
		public async Task Process_UserBlocked_ReturnsFailure()
		{
			// Arrange
			var phoneNumber = "+598 1-111-11-11";
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: phoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: true,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.UserBlocked, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_UserTemporarilyBlocked_ReturnsFailure()
		{
			// Arrange
			var phoneNumber = "+44 11-1111-1111";
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: phoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				Status: UserStatus.NeedToSpecifyBirthDate);
			
			var userTemporaryBan = new UserTemporaryBan(
				Guid.NewGuid(),
				user.Id,
				_dateTimeNowMock.Object.Now.AddSeconds(-300),
				400);

			_context.Users.Add(user.ToModel());
			_context.UserTemporaryBans.Add(userTemporaryBan.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.UserTemporaryBlocked, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ConfirmationCodeAlreadySent_ReturnsFailure()
		{
			// Arrange
			var phoneNumber = "+376 111-111";
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: phoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				Status: UserStatus.NeedToSpecifyBirthDate);
			
			var activeConfirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "1234",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 0);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(activeConfirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.ConfirmationCodeAlreadySent, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_SmsServiceFails_ReturnsFailure()
		{
			// Arrange
			var phoneNumber = "+672 311-111";
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: phoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			_smsServiceMock
				.Setup(service => service.SendSmsMessage(It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync(new SendSmsMessageResult.Failure(new Exception("Sms service error")));

			// Act
			var result = await _useCase.Process(phoneNumber);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(RequireConfirmationCodeErrorType.Other, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_Successful_ReturnsSuccess()
		{
			// Arrange
			var phoneNumber = "+49 111-111";
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: phoneNumber,
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var digitalCode = int.Parse("1" + new string(Enumerable.Repeat('0', _configuration.ConfirmationCodeLength - 1).ToArray()));
			_randomMock.Setup(r => r.RandomInt(_configuration.ConfirmationCodeLength)).Returns(digitalCode);

			_smsServiceMock
				.Setup(service => service.SendSmsMessage(
					It.IsAny<string>(),
					It.IsAny<string>()))
				.ReturnsAsync(new SendSmsMessageResult.Success());

			// Act
			var result = await _useCase.Process(phoneNumber);

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
