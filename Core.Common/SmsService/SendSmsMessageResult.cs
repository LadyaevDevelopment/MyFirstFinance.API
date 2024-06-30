namespace Core.Common.SmsService
{
	public class SendSmsMessageResult
	{
		public bool Successful { get; }

		public Exception? Error { get; }

		private SendSmsMessageResult(bool successful, Exception? error)
		{
			Successful = successful;
			Error = error;
		}

		public class Success() : SendSmsMessageResult(true, null);

		public class Failure(Exception error) : SendSmsMessageResult(false, error);
	}
}
