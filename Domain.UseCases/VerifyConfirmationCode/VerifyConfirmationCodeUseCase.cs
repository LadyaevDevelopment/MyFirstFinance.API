using Core.Common.DateTimeNow;
using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;

namespace Domain.UseCases.VerifyConfirmationCode
{
	public class VerifyConfirmationCodeUseCase(
		IConfirmationCodeRepository confirmationCodeRepository,
		IUserRepository userRepository,
		IDateTimeNow dateTimeNow,
		Configuration configuration)
	{
		public async Task<VerifyConfirmationCodeResult> Process(Guid codeId, string code)
		{
			var confirmationCode = await confirmationCodeRepository.EntityById(codeId);
			if (confirmationCode is null || confirmationCode.Status != ConfirmationCodeStatus.Active)
			{
				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.CodeNotFound,
						TemporaryBlockingTimeInSeconds: null,
						Exception: null));
			}

			var user = await userRepository.EntityById(confirmationCode.UserId);
			if (user is null)
			{
				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.Other,
						TemporaryBlockingTimeInSeconds: null,
						Exception: new Exception("User not found")));
			}
			if (user.IsBlocked)
			{
				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.Other,
						TemporaryBlockingTimeInSeconds: null,
						Exception: new Exception("User is blocked")));
			}
			if (user.UserTemporaryBans.Count > 0)
			{
				foreach (var ban in user.UserTemporaryBans)
				{
					var banTime = dateTimeNow.Now - ban.StartDate;
					if (banTime.TotalSeconds <= ban.DurationInSeconds)
					{
						return new VerifyConfirmationCodeResult.Failure(
						   new VerifyConfirmationCodeError(
							   VerifyConfirmationCodeErrorType.Other,
							   TemporaryBlockingTimeInSeconds: null,
							   Exception: new Exception("User is temporary blocked")));
					}
					else
					{
						await userRepository.RemoveTemporaryBanById(ban.Id);
					}
				}
			}

			var codeLifeTime = dateTimeNow.Now - confirmationCode.CreationDate;
			if (codeLifeTime.TotalSeconds > configuration.ConfirmationCodeLifeTimeInSeconds
				|| codeLifeTime.TotalSeconds > configuration.ResendConfirmationCodeTimeInSeconds)
			{
				await confirmationCodeRepository.SavedEntity(
					confirmationCode with { Status = ConfirmationCodeStatus.Inactive });

				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.CodeLifeTimeExpired,
						TemporaryBlockingTimeInSeconds: null,
						Exception: null));
			}

			if (confirmationCode.Code != code)
			{
				confirmationCode = confirmationCode
					with { FailedCodeConfirmationAttemptCount = confirmationCode.FailedCodeConfirmationAttemptCount + 1 };
				await confirmationCodeRepository.SavedEntity(confirmationCode);
				
				if (confirmationCode.FailedCodeConfirmationAttemptCount > configuration.AllowedFailedCodeConfirmationAttemptCount)
				{
					var userBan = new UserTemporaryBan(
						Id: default,
						user.Id,
						dateTimeNow.Now,
						configuration.UserTemporaryBlockingTimeInSeconds);
					await userRepository.SavedTemporaryBan(userBan);

					return new VerifyConfirmationCodeResult.Failure(
						new VerifyConfirmationCodeError(
							VerifyConfirmationCodeErrorType.FailedCodeConfirmationAttemptCountExceeded,
							TemporaryBlockingTimeInSeconds: configuration.UserTemporaryBlockingTimeInSeconds,
							Exception: null));
				}
				else
				{
					return new VerifyConfirmationCodeResult.Failure(
						new VerifyConfirmationCodeError(
							VerifyConfirmationCodeErrorType.WrongCode,
							TemporaryBlockingTimeInSeconds: null,
							Exception: null));
				}
			}

			await confirmationCodeRepository.SavedEntity(
				confirmationCode with { Status = ConfirmationCodeStatus.Used });

			return new VerifyConfirmationCodeResult.Success(
				new VerifyConfirmationCodeData(confirmationCode.UserId));
		}
	}
}
