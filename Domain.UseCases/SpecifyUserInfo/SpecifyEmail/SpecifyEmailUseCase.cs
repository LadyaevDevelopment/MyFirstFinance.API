using Core.Common.Email;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SpecifyEmail
{
    public class SpecifyEmailUseCase(
		IUserRepository userRepository,
		UserStatusStrategy provisioningUserData,
		IEmailValidation emailValidation,
		Configuration configuration)
	{
		public async Task<SpecifyUserInfoResult> Process(Guid userId, string email)
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

			if (!emailValidation.IsValid(email))
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.InvalidData, Exception: new Exception("Invalid e-mail format")));
			}

            user = user with
            {
				Email = email
            };
            var actualStatus = provisioningUserData.ActualStatus(user);
            user = user with { Status = actualStatus };
            await userRepository.SavedEntity(user);

            int? pinCodeLength = actualStatus == UserStatus.NeedToCreatePinCode ? configuration.PinCodeLength : null;

            return new SpecifyUserInfoResult.Success(new SpecifyUserInfoData(actualStatus, pinCodeLength));
		}
	}
}
