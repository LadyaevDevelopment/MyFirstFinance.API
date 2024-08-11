using Core.Common.FileService;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SpecifyIdentityDocument
{
    public class SpecifyIdentityDocumentUseCase(
		IUserRepository userRepository,
		UserStatusStrategy provisioningUserData,
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

            user = user with
            {
                IdentityDocument = identityDocument
            };
            var actualStatus = provisioningUserData.ActualStatus(user);
            user = user with { Status = actualStatus };
            await userRepository.SavedEntity(user);

            int? pinCodeLength = actualStatus == UserStatus.NeedToCreatePinCode ? configuration.PinCodeLength : null;

            return new SpecifyUserInfoResult.Success(new SpecifyUserInfoData(actualStatus, pinCodeLength));
		}
	}
}
