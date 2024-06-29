using Domain.Entities.ConfirmationCodes;
using Domain.Entities.Misc;
using Domain.Entities.Users;
using Domain.Repository;
using Domain.Services.DateTimeNow;

namespace Domain.UseCases.VerifyConfirmationCode
{
	public class VerifyConfirmationCodeUseCase(
		IConfirmationCodeRepository confirmationCodeRepository,
		IUserRepository userRepository,
		DateTimeNow dateTimeNow,
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
						ErrorMessage: null));
			}

			var user = await userRepository.EntityById(confirmationCode.UserId);
			if (user is null)
			{
				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.Other,
						TemporaryBlockingTimeInSeconds: null,
						ErrorMessage: "User not found"));
			}
			if (user.IsBlocked)
			{
				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.Other,
						TemporaryBlockingTimeInSeconds: null,
						ErrorMessage: "User is blocked"));
			}
			if (user.UserTemporaryBans.Count > 0)
			{
				foreach (var ban in user.UserTemporaryBans)
				{
					var banTime = dateTimeNow.Now - ban.StartDate;
					if (banTime.Seconds <= configuration.UserTemporaryBlockingTimeInSeconds)
					{
						return new VerifyConfirmationCodeResult.Failure(
						   new VerifyConfirmationCodeError(
							   VerifyConfirmationCodeErrorType.Other,
							   TemporaryBlockingTimeInSeconds: null,
							   ErrorMessage: "User is temporary blocked"));
					}
					else
					{
						await userRepository.RemoveBanById(ban.Id);
					}
				}
			}

			var codeLifeTime = dateTimeNow.Now - confirmationCode.CreationDate;
			if (codeLifeTime.Seconds > configuration.ConfirmationCodeLifeTimeInSeconds
				|| codeLifeTime.Seconds > configuration.ResendConfirmationCodeTimeInSeconds)
			{
				await confirmationCodeRepository.SavedEntity(
					confirmationCode with { Status = ConfirmationCodeStatus.Inactive });

				return new VerifyConfirmationCodeResult.Failure(
					new VerifyConfirmationCodeError(
						VerifyConfirmationCodeErrorType.CodeLifeTimeExpired,
						TemporaryBlockingTimeInSeconds: null,
						ErrorMessage: null));
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
							ErrorMessage: null));
				}
				else
				{
					return new VerifyConfirmationCodeResult.Failure(
						new VerifyConfirmationCodeError(
							VerifyConfirmationCodeErrorType.WrongCode,
							TemporaryBlockingTimeInSeconds: null,
							ErrorMessage: null));
				}
			}

			await confirmationCodeRepository.SavedEntity(
				confirmationCode with { Status = ConfirmationCodeStatus.Used });

			return new VerifyConfirmationCodeResult.Success(
				new VerifyConfirmationCodeData(confirmationCode.UserId));
		}
	}
}
