﻿using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument
{
	public class SkipProvisioningIdentityDocumentUseCase(
		IUserRepository userRepository,
		ProvisioningUserData provisioningUserData,
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

			var identityDocument = new IdentityDocument(
				Id: default,
				userId,
				Skipped: true,
				Path: null);
			await userRepository.SavedIdentityDocument(identityDocument);

			var nextStep = provisioningUserData.NextStep(user);
			int? pinCodeLength = nextStep == ProvisioningUserDataStep.PinCode ? configuration.PinCodeLength : null;

			return new SkipProvisioningIdentityDocumentResult.Success(
				new SpecifyUserInfoData(
					AllDataProvided: nextStep is null,
					nextStep,
					pinCodeLength));
		}
	}
}
