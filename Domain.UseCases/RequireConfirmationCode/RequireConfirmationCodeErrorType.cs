namespace Domain.UseCases.RequireConfirmationCode
{
	public enum RequireConfirmationCodeErrorType
	{
		UserBlocked = 1,
		UserTemporaryBlocked = 2,
		ConfirmationCodeAlreadySent = 3,
		Other = 4
	}
}
