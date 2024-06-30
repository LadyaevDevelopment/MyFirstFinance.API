using Core.Common.DateTimeNow;
using Core.Common.Random;
using Core.Common.SmsService;
using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;

namespace Domain.UseCases.RequireConfirmationCode
{
	public class RequireConfirmationCodeUseCase(
		ISmsService smsService,
		IRandom random,
		IConfirmationCodeRepository confirmationCodeRepository,
		IUserRepository userRepository,
		IDateTimeNow dateTimeNow,
		Configuration configuration)
    {
        public async Task<RequireConfirmationCodeResult> Process(string phoneNumber)
        {
            var user = (await userRepository.FilteredEntities(new UserSearchParams
            {
                PhoneNumber = phoneNumber,
            })).FirstOrDefault();
            if (user is null)
            {
                user = new User(
                    Id: default,
                    LastName: null,
                    FirstName: null,
                    MiddleName: null,
                    BirthDate: null,
                    PinCode: null,
                    PhoneNumber: phoneNumber,
                    Email: null,
                    AvatarPath: null,
                    IsBlocked: false,
                    Status: UserStatus.NeedToSpecifyBirthDate);
				user = await userRepository.SavedEntity(user);
			}
			if (user.IsBlocked)
			{
				return new RequireConfirmationCodeResult.Failure(
					new RequireConfirmationCodeError(
						RequireConfirmationCodeErrorType.UserBlocked,
						RemainingTemporaryBlockingTimeInSeconds: null,
						Exception: null));
			}
			if (user.UserTemporaryBans.Count > 0)
			{
                foreach (var ban in user.UserTemporaryBans)
                {
                    var banTime = dateTimeNow.Now - ban.StartDate;
                    if (banTime.TotalSeconds <= ban.DurationInSeconds)
                    {
						return new RequireConfirmationCodeResult.Failure(
		                   new RequireConfirmationCodeError(
			                   RequireConfirmationCodeErrorType.UserTemporaryBlocked,
			                   configuration.UserTemporaryBlockingTimeInSeconds - banTime.Seconds,
							   Exception: null));
					}
                    else
                    {
                        await userRepository.RemoveTemporaryBanById(ban.Id);
                    }
                }
			}

			var activeConfirmationCodes = await confirmationCodeRepository.FilteredEntities(new ConfirmationCodeSearchParams
            {
                UserId = user.Id,
                Status = ConfirmationCodeStatus.Active
            });

            foreach (var activeConfirmationCode in activeConfirmationCodes)
            {
                var codeLifeTime = dateTimeNow.Now - activeConfirmationCode.CreationDate;
				if (codeLifeTime.TotalSeconds > configuration.ConfirmationCodeLifeTimeInSeconds
                    || codeLifeTime.TotalSeconds > configuration.ResendConfirmationCodeTimeInSeconds)
                {
                    await confirmationCodeRepository.SavedEntity(
                        activeConfirmationCode with { Status = ConfirmationCodeStatus.Inactive });
				}
                else
                {
                    return new RequireConfirmationCodeResult.Failure(
                        new RequireConfirmationCodeError(
                            RequireConfirmationCodeErrorType.ConfirmationCodeAlreadySent,
                            RemainingTemporaryBlockingTimeInSeconds: null,
							Exception: null));
				}
            }

            var digitalCode = random.RandomInt(configuration.ConfirmationCodeLength).ToString();
            var sendResult = await smsService.SendSmsMessage(phoneNumber, digitalCode);
            if (!sendResult.Successful)
            {
				return new RequireConfirmationCodeResult.Failure(
					new RequireConfirmationCodeError(
						RequireConfirmationCodeErrorType.Other,
						RemainingTemporaryBlockingTimeInSeconds: null,
						Exception: sendResult.Error));
			}

            var confirmationCode = new ConfirmationCode(
                Id: default,
                user.Id,
                digitalCode,
				dateTimeNow.Now,
                ConfirmationCodeStatus.Active,
                FailedCodeConfirmationAttemptCount: 0);
			confirmationCode = await confirmationCodeRepository.SavedEntity(confirmationCode);

            return new RequireConfirmationCodeResult.Success(
                new RequireConfirmationCodeData(
                    confirmationCode.Id,
                    digitalCode.Length,
                    configuration.ResendConfirmationCodeTimeInSeconds,
                    configuration.AllowedFailedCodeConfirmationAttemptCount,
                    configuration.ConfirmationCodeLifeTimeInSeconds));
		}
    }
}
