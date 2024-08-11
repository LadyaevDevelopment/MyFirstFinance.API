using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SpecifyPinCode
{
    public class SpecifyPinCodeUseCase(
		IUserRepository userRepository,
		UserStatusStrategy provisioningUserData,
		Configuration configuration)
	{
		public async Task<SpecifyUserInfoResult> Process(Guid userId, string pinCode)
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

			if (pinCode.Length != configuration.PinCodeLength)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.InvalidData, Exception: new Exception("Wrong pin code length")));
			}
			if (pinCode.Any(item => !char.IsDigit(item)))
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.InvalidData, Exception: new Exception("Invalid pin code format")));
			}

            user = user with
            {
                PinCode = pinCode,
            };
            var actualStatus = provisioningUserData.ActualStatus(user);
            user = user with { Status = actualStatus };
            await userRepository.SavedEntity(user);

            int? pinCodeLength = actualStatus == UserStatus.NeedToCreatePinCode ? configuration.PinCodeLength : null;

            return new SpecifyUserInfoResult.Success(new SpecifyUserInfoData(actualStatus, pinCodeLength));
		}
	}
}
