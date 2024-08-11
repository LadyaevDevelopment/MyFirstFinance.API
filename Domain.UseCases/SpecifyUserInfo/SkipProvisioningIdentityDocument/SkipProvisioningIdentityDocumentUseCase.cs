using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument
{
    public class SkipProvisioningIdentityDocumentUseCase(
		IUserRepository userRepository,
		UserStatusStrategy provisioningUserData,
		Configuration configuration)
	{
		public async Task<SkipProvisioningIdentityDocumentResult> Process(Guid userId)
		{
			var user = await userRepository.EntityById(userId);
			if (user is null)
			{
				return new SkipProvisioningIdentityDocumentResult.Failure(
					new SkipProvisioningIdentityDocumentError(
						SkipProvisioningIdentityDocumentErrorType.UserNotFound, Exception: null));
			}

			var existingIdentityDocument = await userRepository.IdentityDocument(userId);
			if (existingIdentityDocument?.Skipped == false)
			{
				return new SkipProvisioningIdentityDocumentResult.Failure(
					new SkipProvisioningIdentityDocumentError(
						SkipProvisioningIdentityDocumentErrorType.Other,
						Exception: new Exception("The identity document has been already specified")));
			}

			var identityDocument = new IdentityDocument(
				Id: default,
				userId,
				Skipped: true,
				Path: null);
			await userRepository.SavedIdentityDocument(identityDocument);

            user = user with
            {
                IdentityDocument = identityDocument,
            };
            var actualStatus = provisioningUserData.ActualStatus(user);
            user = user with { Status = actualStatus };
            await userRepository.SavedEntity(user);
            
			int? pinCodeLength = actualStatus == UserStatus.NeedToCreatePinCode ? configuration.PinCodeLength : null;

			return new SkipProvisioningIdentityDocumentResult.Success(new SpecifyUserInfoData(actualStatus, pinCodeLength));
		}
	}
}
