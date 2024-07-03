using Core.Common.DateTimeNow;
using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.Users;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.UseCases.SpecifyUserData.SpecifyBirthDate;
using Domain.UseCases.SpecifyUserInfo.Base;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Domain.UseCases.Tests
{
	public class SpecifyBirthDateUseCaseTests
	{
		private readonly DefaultDbContext _context;
		private readonly UserRepository _userRepository;

		private readonly Mock<IDateTimeNow> _dateTimeNowMock;
		private readonly Configuration _configuration;
		private readonly SpecifyBirthDateUseCase _useCase;
		private readonly ProvisioningUserData _provisioningUserData;

		public SpecifyBirthDateUseCaseTests()
		{
			var options = new DbContextOptionsBuilder<DefaultDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			_context = new DefaultDbContext(options);
			_userRepository = new UserRepository(_context);

			_dateTimeNowMock = new Mock<IDateTimeNow>();
			_dateTimeNowMock.Setup(dateTime => dateTime.Now)
				.Returns(DateTime.UtcNow);

			_provisioningUserData = new ProvisioningUserData.Base();

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

			_useCase = new SpecifyBirthDateUseCase(
				_userRepository,
				_provisioningUserData,
				_dateTimeNowMock.Object,
				_configuration);
		}

		[Fact]
		public async Task Process_UserNotFound_ReturnsFailure()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+34 (111)111-111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(Guid.NewGuid(), new DateOnly(2000, 1, 1));

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(SpecifyBirthDateErrorType.UserNotFound, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_BirthDateAlreadySpecified_ReturnsFailure()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: DateOnly.FromDateTime(_dateTimeNowMock.Object.Now),
				PinCode: null,
				PhoneNumber: "+228 11-111-111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyName);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id, new DateOnly(1990, 1, 1));

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(SpecifyBirthDateErrorType.AlreadySpecified, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_BirthDateInTheFuture_ReturnsFailure()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+975 17-111-111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id, DateOnly.FromDateTime(_dateTimeNowMock.Object.Now.AddDays(1)));

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(SpecifyBirthDateErrorType.InvalidData, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_UserIsMinor_ReturnsFailure()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+975 1-111-111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id, DateOnly.FromDateTime(_dateTimeNowMock.Object.Now.AddYears(-17)));

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(SpecifyBirthDateErrorType.UserIsMinor, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ValidBirthDate_ReturnsSuccess()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+975 1-111-111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id, DateOnly.FromDateTime(_dateTimeNowMock.Object.Now.AddYears(-18)));

			// Assert
			Assert.True(result.Successful);
			Assert.NotNull(result.Data);
		}
	}
}
