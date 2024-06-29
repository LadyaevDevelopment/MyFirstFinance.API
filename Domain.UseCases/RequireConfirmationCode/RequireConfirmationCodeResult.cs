namespace Domain.UseCases.RequireConfirmationCode
{
	public class RequireConfirmationCodeResult
	{
		public bool Successful { get; }

		public RequireConfirmationCodeData? Data { get; }

		public RequireConfirmationCodeError? Error { get; }

		private RequireConfirmationCodeResult(bool successful, RequireConfirmationCodeData? data, RequireConfirmationCodeError? error)
		{
			Successful = successful;
			Data = data;
			Error = error;
		}

		public class Success(RequireConfirmationCodeData data) : RequireConfirmationCodeResult(true, data, null);

		public class Failure(RequireConfirmationCodeError error) : RequireConfirmationCodeResult(false, null, error);
	}
}
