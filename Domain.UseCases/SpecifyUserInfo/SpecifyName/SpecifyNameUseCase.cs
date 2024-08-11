using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SpecifyName
{
    public class SpecifyNameUseCase(
		IUserRepository userRepository,
		UserStatusStrategy provisioningUserData,
		Configuration configuration)
	{
		public async Task<SpecifyUserInfoResult> Process(
			Guid userId,
			string lastName,
			string firstName,
			string? middleName)
		{
			var user = await userRepository.EntityById(userId);
			if (user is null)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.UserNotFound, Exception: null));
			}
			if (user.FirstName != null)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.AlreadySpecified, Exception: null));
			}

			lastName = lastName.Trim().ToLower();
			firstName = lastName.Trim().ToLower();
			middleName = middleName is null ? middleName : middleName.Trim().ToLower();

			if (lastName.Length == 0 || lastName.Any(item => !char.IsAsciiLetter(item))
				|| firstName.Length == 0 || firstName.Any(item => !char.IsAsciiLetter(item))
				|| middleName != null && (middleName.Length == 0 || middleName.Any(item => !char.IsAsciiLetter(item))))
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.InvalidData,
						Exception: new Exception("Correct name must be not empty and can contain only letters")));
			}

			user = user with
			{
				LastName = lastName,
				FirstName = firstName,
				MiddleName = middleName
			};
            var actualStatus = provisioningUserData.ActualStatus(user);
            user = user with { Status = actualStatus };
            await userRepository.SavedEntity(user);

			int? pinCodeLength = actualStatus == UserStatus.NeedToCreatePinCode ? configuration.PinCodeLength : null;

			return new SpecifyUserInfoResult.Success(new SpecifyUserInfoData(actualStatus, pinCodeLength));
		}
	}
}
