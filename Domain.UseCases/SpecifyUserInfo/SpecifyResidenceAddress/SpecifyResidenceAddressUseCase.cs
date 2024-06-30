using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SpecifyResidenceAddress
{
	public class SpecifyResidenceAddressUseCase(
		IUserRepository userRepository,
		ProvisioningUserData provisioningUserData,
		Configuration configuration)
	{
		public async Task<SpecifyUserInfoResult> Process(
			Guid userId,
			Guid countryId,
			string city,
			string street,
			string buildingNumber,
			string apartmentNumber)
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

			if (city.Length == 0 || street.Length == 0 || buildingNumber.Length == 0 || apartmentNumber.Length == 0)
			{
				return new SpecifyUserInfoResult.Failure(
					new SpecifyUserInfoError(
						SpecifyUserInfoErrorType.InvalidData, Exception: new Exception("Empty data field")));
			}

			var residenceAddress = new UserResidenceAddress(
				Id: default,
				countryId,
				city,
				street,
				buildingNumber,
				apartmentNumber);
			await userRepository.SavedResidenceAddress(residenceAddress);

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
