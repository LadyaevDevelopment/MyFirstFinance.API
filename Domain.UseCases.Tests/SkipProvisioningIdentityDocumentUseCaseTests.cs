using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Repository.Users;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.UseCases.SpecifyUserInfo.Base;
using Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument;
using Microsoft.EntityFrameworkCore;

namespace Domain.UseCases.Tests
{
	public class SkipProvisioningIdentityDocumentUseCaseTests
	{
		private readonly DefaultDbContext _context;
		private readonly UserRepository _userRepository;

		private readonly Configuration _configuration;
		private readonly SkipProvisioningIdentityDocumentUseCase _useCase;
		private readonly ProvisioningUserData _provisioningUserData;

		public SkipProvisioningIdentityDocumentUseCaseTests()
		{
			var options = new DbContextOptionsBuilder<DefaultDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			_context = new DefaultDbContext(options);
			_userRepository = new UserRepository(_context);

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

			_useCase = new SkipProvisioningIdentityDocumentUseCase(
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
				PhoneNumber: "+968 7711-11-11",
				Email: null,
				AvatarPath: null,
				IsBlocked: false,
				Status: UserStatus.NeedToSpecifyIdentityDocument);

			_context.Users.Add(user.ToModel());
			await _context.SaveChangesAsync();

			// Act
			var result = await _useCase.Process(user.Id);

			// Assert
			Assert.True(result.Successful);
			Assert.NotNull(result.Data);
		}
	}
}
