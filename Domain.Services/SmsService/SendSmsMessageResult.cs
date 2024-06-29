namespace Domain.Services.SmsService
{
	public class SendSmsMessageResult
	{
		public bool Successful { get; }

		public string? ErrorMessage { get; }

		private SendSmsMessageResult(bool successful, string? errorMessage)
		{
			Successful = successful;
			ErrorMessage = errorMessage;
		}

		public class Success() : SendSmsMessageResult(true, null);

		public class Failure(string errorMessage) : SendSmsMessageResult(false, errorMessage);
	}
}
