using Core.Common.DateTimeNow;
using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.ConfirmationCodes;
using Data.Production.Repository.Users;
using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.UseCases.VerifyConfirmationCode;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Domain.UseCases.Tests
{
	public class VerifyConfirmationCodeUseCaseTests
	{
		private readonly DefaultDbContext _context;
		private readonly UserRepository _userRepository;
		private readonly ConfirmationCodeRepository _confirmationCodeRepository;

		private readonly Mock<IDateTimeNow> _dateTimeNowMock;
		private readonly Configuration _configuration;
		private readonly VerifyConfirmationCodeUseCase _useCase;

		public VerifyConfirmationCodeUseCaseTests()
		{
			var options = new DbContextOptionsBuilder<DefaultDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			_context = new DefaultDbContext(options);
			_userRepository = new UserRepository(_context);
			_confirmationCodeRepository = new ConfirmationCodeRepository(_context);

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

			_useCase = new VerifyConfirmationCodeUseCase(
				_confirmationCodeRepository,
				_userRepository,
				_dateTimeNowMock.Object,
				_configuration);
		}

		[Fact]
		public async Task Process_ShouldReturnCodeNotFound_WhenConfirmationCodeDoesNotExist()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+49 (111)11-11",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var confirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 0);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(confirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(Guid.NewGuid(), "123456");

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(VerifyConfirmationCodeErrorType.CodeNotFound, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ShouldReturnCodeNotFound_WhenConfirmationCodeIsInactive()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+49 (111)11-1111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var confirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Inactive,
				FailedCodeConfirmationAttemptCount: 0);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(confirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(confirmationCode.Id, "123456");

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(VerifyConfirmationCodeErrorType.CodeNotFound, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ShouldReturnCodeLifeTimeExpired_WhenCodeLifeTimeExpired()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+49 (111)11-11",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var confirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-700),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 0);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(confirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(confirmationCode.Id, "123456");

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(VerifyConfirmationCodeErrorType.CodeLifeTimeExpired, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ShouldReturnWrongCode_WhenCodeIsIncorrect()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+49 (111)11-111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var confirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 0);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(confirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(confirmationCode.Id, "123457");

			confirmationCode = await _confirmationCodeRepository.EntityById(confirmationCode.Id);

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(VerifyConfirmationCodeErrorType.WrongCode, result.Error.ErrorType);
			Assert.Equal(1, confirmationCode!.FailedCodeConfirmationAttemptCount);
		}

		[Fact]
		public async Task Process_ShouldReturnWrongCode_FailedCodeConfirmationAttemptCountExceeded()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+49 (1111)111-1111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var confirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 3);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(confirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(confirmationCode.Id, "123457");

			// Assert
			Assert.False(result.Successful);
			Assert.NotNull(result.Error);
			Assert.Equal(VerifyConfirmationCodeErrorType.FailedCodeConfirmationAttemptCountExceeded, result.Error.ErrorType);
		}

		[Fact]
		public async Task Process_ShouldReturnSuccess_WhenCodeIsCorrect()
		{
			// Arrange
			var user = new User(
				Id: Guid.NewGuid(),
				LastName: "LastName",
				FirstName: "FirstName",
				MiddleName: null,
				BirthDate: null,
				PinCode: null,
				PhoneNumber: "+49 (111)111-1111",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyBirthDate);

			var confirmationCode = new ConfirmationCode(
				Id: Guid.NewGuid(),
				UserId: user.Id,
				Code: "123456",
				CreationDate: _dateTimeNowMock.Object.Now.AddSeconds(-60),
				Status: ConfirmationCodeStatus.Active,
				FailedCodeConfirmationAttemptCount: 3);

			_context.Users.Add(user.ToModel());
			_context.ConfirmationCodes.Add(confirmationCode.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(confirmationCode.Id, "123456");

			// Assert
			Assert.True(result.Successful);
			Assert.NotNull(result.Data);
			Assert.Null(result.Error);
		}
	}
}
