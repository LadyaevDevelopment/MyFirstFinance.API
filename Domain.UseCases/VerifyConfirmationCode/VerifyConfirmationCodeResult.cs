namespace Domain.UseCases.VerifyConfirmationCode
{
	public class VerifyConfirmationCodeResult
	{
		public bool Successful { get; }

		public VerifyConfirmationCodeData? Data { get; }

		public VerifyConfirmationCodeError? Error { get; }

		private VerifyConfirmationCodeResult(bool successful, VerifyConfirmationCodeData? data, VerifyConfirmationCodeError? error)
		{
			Successful = successful;
			Data = data;
			Error = error;
		}

		public class Success(VerifyConfirmationCodeData data) : VerifyConfirmationCodeResult(true, data, null);

		public class Failure(VerifyConfirmationCodeError error) : VerifyConfirmationCodeResult(false, null, error);
	}
}
