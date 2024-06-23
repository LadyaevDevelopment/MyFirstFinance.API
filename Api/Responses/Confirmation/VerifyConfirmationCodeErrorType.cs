namespace Api.Responses.Confirmation
{
	public enum VerifyConfirmationCodeErrorType
	{
		WrongCode = 1,
		CodeLifeTimeExpired = 2,
		AllowedConfirmCodeAttemptCountExceeded = 3,
	}
}
