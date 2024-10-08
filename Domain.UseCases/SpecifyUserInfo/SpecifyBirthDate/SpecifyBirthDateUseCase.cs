﻿using Core.Common.DateTimeNow;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserData.SpecifyBirthDate
{
    public class SpecifyBirthDateUseCase(
        IUserRepository userRepository,
		UserStatusStrategy provisioningUserData,
		IDateTimeNow dateTimeNow,
        Configuration configuration)
    {
        public async Task<SpecifyBirthDateResult> Process(Guid userId, DateOnly birthDate)
        {
            var user = await userRepository.EntityById(userId);
            if (user is null)
            {
                return new SpecifyBirthDateResult.Failure(
                    new SpecifyBirthDateError(
                        SpecifyBirthDateErrorType.UserNotFound, Exception: null));
            }
            if (user.BirthDate != null)
            {
				return new SpecifyBirthDateResult.Failure(
	                new SpecifyBirthDateError(
		                SpecifyBirthDateErrorType.AlreadySpecified, Exception: null));
			}
            if (birthDate.ToDateTime(new TimeOnly(0, 0)) > dateTimeNow.Now)
            {
				return new SpecifyBirthDateResult.Failure(
	                new SpecifyBirthDateError(
		                SpecifyBirthDateErrorType.InvalidData, Exception: new Exception("Specified birth date is in the future")));
			}
            
            var age = Age(birthDate);
            if (age > 100)
            {
				return new SpecifyBirthDateResult.Failure(
	                new SpecifyBirthDateError(
		                SpecifyBirthDateErrorType.InvalidData, Exception: new Exception("Specified birth date is too old")));
			}
			if (age < configuration.MinUserAge)
            {
                return new SpecifyBirthDateResult.Failure(
                    new SpecifyBirthDateError(
                        SpecifyBirthDateErrorType.UserIsMinor, Exception: null));
            }
            
            user = user with
            {
                BirthDate = birthDate,
            };
            var actualStatus = provisioningUserData.ActualStatus(user);
            user = user with { Status = actualStatus };
            await userRepository.SavedEntity(user);

            int? pinCodeLength = actualStatus == UserStatus.NeedToCreatePinCode ? configuration.PinCodeLength : null;

            return new SpecifyBirthDateResult.Success(new SpecifyUserInfoData(actualStatus, pinCodeLength));
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
