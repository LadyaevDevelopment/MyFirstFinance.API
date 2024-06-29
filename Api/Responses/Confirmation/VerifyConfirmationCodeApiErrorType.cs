namespace Api.Responses.Confirmation
{
	public enum VerifyConfirmationCodeApiErrorType
	{
		WrongCode = 1,
		CodeLifeTimeExpired = 2,
		FailedCodeConfirmationAttemptCountExceeded = 3,
	}
}
