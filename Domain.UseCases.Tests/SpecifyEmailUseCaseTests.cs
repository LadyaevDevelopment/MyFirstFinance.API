using Core.Common.Email;
using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.Users;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.UseCases.SpecifyUserInfo.Base;
using Domain.UseCases.SpecifyUserInfo.SpecifyEmail;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Domain.UseCases.Tests
{
	public class SpecifyEmailUseCaseTests
	{
		private readonly DefaultDbContext _context;
		private readonly UserRepository _userRepository;

		private readonly Configuration _configuration;
		private readonly SpecifyEmailUseCase _useCase;
		private readonly ProvisioningUserData _provisioningUserData;
		private readonly Mock<IEmailValidation> _emailValidationMock;

		public SpecifyEmailUseCaseTests()
		{
			var options = new DbContextOptionsBuilder<DefaultDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			_context = new DefaultDbContext(options);
			_userRepository = new UserRepository(_context);

			_emailValidationMock = new Mock<IEmailValidation>();
			_emailValidationMock.Setup(item => item.IsValid(It.IsAny<string>()))
				.Returns(true);

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

			_useCase = new SpecifyEmailUseCase(
				_userRepository,
				_provisioningUserData,
				_emailValidationMock.Object,
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
				PhoneNumber: "+968 7711-11-11",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				RegistrationDate: DateTime.Now,
				Status: UserStatus.NeedToSpecifyEmail);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id, "email");

			// Assert
			Assert.True(result.Successful);
			Assert.NotNull(result.Data);
		}
	}
}
