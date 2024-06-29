using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.Services.CodeGeneration;
using Domain.Services.DateTimeNow;
using Domain.Services.SmsService;

namespace Domain.UseCases.RequireConfirmationCode
{
	public class RequireConfirmationCodeUseCase(
		ISmsService smsService,
		CodeGeneration codeGeneration,
		IConfirmationCodeRepository confirmationCodeRepository,
		IUserRepository userRepository,
		DateTimeNow dateTimeNow,
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
						ErrorMessage: null));
			}
			if (user.UserTemporaryBans.Count > 0)
			{
                foreach (var ban in user.UserTemporaryBans)
                {
                    var banTime = dateTimeNow.Now - ban.StartDate;
                    if (banTime.Seconds <= configuration.UserTemporaryBlockingTimeInSeconds)
                    {
						return new RequireConfirmationCodeResult.Failure(
		                   new RequireConfirmationCodeError(
			                   RequireConfirmationCodeErrorType.UserTemporaryBlocked,
			                   configuration.UserTemporaryBlockingTimeInSeconds - banTime.Seconds,
			                   ErrorMessage: null));
					}
                    else
                    {
                        await userRepository.RemoveBanById(ban.Id);
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
				if (codeLifeTime.Seconds > configuration.ConfirmationCodeLifeTimeInSeconds
                    || codeLifeTime.Seconds > configuration.ResendConfirmationCodeTimeInSeconds)
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
                            ErrorMessage: null));
				}
            }

            var digitalCode = codeGeneration.DigitalCode(configuration.ConfirmationCodeLength);
            var sendResult = await smsService.SendSmsMessage(phoneNumber, digitalCode);
            if (!sendResult.Successful)
            {
				return new RequireConfirmationCodeResult.Failure(
					new RequireConfirmationCodeError(
						RequireConfirmationCodeErrorType.Other,
						RemainingTemporaryBlockingTimeInSeconds: null,
						ErrorMessage: sendResult.ErrorMessage));
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
