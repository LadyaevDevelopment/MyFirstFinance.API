using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.Services.DateTimeNow;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserData.SpecifyBirthDate
{
	public class SpecifyBirthDateUseCase(
        IUserRepository userRepository,
		ProvisioningUserData provisioningUserData,
		DateTimeNow dateTimeNow,
        Configuration configuration)
    {
        public async Task<SpecifyBirthDateResult> Process(Guid userId, DateOnly birthDate)
        {
            var user = await userRepository.EntityById(userId);
            if (user is null)
            {
                return new SpecifyBirthDateResult.Failure(
                    new SpecifyBirthDateError(
                        SpecifyBirthDateErrorType.UserNotFound, ErrorMessage: null));
            }
            if (user.BirthDate != null)
            {
				return new SpecifyBirthDateResult.Failure(
	                new SpecifyBirthDateError(
		                SpecifyBirthDateErrorType.AlreadySpecified, ErrorMessage: null));
			}
            if (birthDate.ToDateTime(new TimeOnly(0, 0)) > dateTimeNow.Now)
            {
				return new SpecifyBirthDateResult.Failure(
	                new SpecifyBirthDateError(
		                SpecifyBirthDateErrorType.InvalidData, ErrorMessage: "Specified birth date is in the future"));
			}
            
            var age = Age(birthDate);
            if (age > 100)
            {
				return new SpecifyBirthDateResult.Failure(
	                new SpecifyBirthDateError(
		                SpecifyBirthDateErrorType.InvalidData, ErrorMessage: "Specified birth date is too old"));
			}
			if (age < configuration.MinUserAge)
            {
                return new SpecifyBirthDateResult.Failure(
                    new SpecifyBirthDateError(
                        SpecifyBirthDateErrorType.UserIsMinor, ErrorMessage: null));
            }
            
            user = await userRepository.SavedEntity(user with { BirthDate = birthDate });
            
            var nextStep = provisioningUserData.NextStep(user);
            int? pinCodeLength = nextStep == ProvisioningUserDataStep.PinCode ? configuration.PinCodeLength : null;

            return new SpecifyBirthDateResult.Success(
                new SpecifyUserInfoData(
                    AllDataProvided: nextStep is null,
                    nextStep,
                    pinCodeLength));
		}

        private int Age(DateOnly birthDate)
		{
			var birthDateTime = birthDate.ToDateTime(new TimeOnly(0, 0));
			var age = dateTimeNow.Now.Year - birthDateTime.Year;
			if (dateTimeNow.Now < birthDateTime.AddYears(age))
			{
				age--;
			}
			return age;
		}
	}
}
