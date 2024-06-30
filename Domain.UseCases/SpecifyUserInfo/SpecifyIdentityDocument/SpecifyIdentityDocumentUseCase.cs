using Core.Common.FileService;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SpecifyIdentityDocument
{
	public class SpecifyIdentityDocumentUseCase(
		IUserRepository userRepository,
		ProvisioningUserData provisioningUserData,
		IFileService fileService,
		Configuration configuration)
	{
		public async Task<SpecifyUserInfoResult> Process(Guid userId, byte[] content)
		{
			var user = await userRepository.EntityById(userId);
			if (user is null)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.UserNotFound, Exception: null));
			}
			if (user.Email != null)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.AlreadySpecified, Exception: null));
			}

			var result = await fileService.SavedFile(content, configuration.UploadsDirectoryPath);
			if (!result.Successful)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.Other, Exception: result.Error));
			}

			var identityDocument = new IdentityDocument(
				Id: default,
				userId,
				Skipped: false,
				result.Data!.Path);
			await userRepository.SavedIdentityDocument(identityDocument);

			var nextStep = provisioningUserData.NextStep(user);
			int? pinCodeLength = nextStep == ProvisioningUserDataStep.PinCode ? configuration.PinCodeLength : null;

			return new SpecifyUserInfoResult.Success(
				new SpecifyUserInfoData(
					AllDataProvided: nextStep is null,
					nextStep,
					pinCodeLength));
		}
	}
}
