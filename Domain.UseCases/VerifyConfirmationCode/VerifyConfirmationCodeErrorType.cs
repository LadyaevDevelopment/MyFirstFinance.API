namespace Domain.UseCases.VerifyConfirmationCode
{
	public enum VerifyConfirmationCodeErrorType
	{
		CodeNotFound = 1,
		WrongCode = 2,
		CodeLifeTimeExpired = 3,
		FailedCodeConfirmationAttemptCountExceeded = 4,
		Other = 5,
	}
}
