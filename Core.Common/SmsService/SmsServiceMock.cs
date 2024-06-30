namespace Core.Common.SmsService
{
	public class SmsServiceMock : ISmsService
	{
		public Task<SendSmsMessageResult> SendSmsMessage(string phoneNumber, string message)
		{
			return Task.FromResult((SendSmsMessageResult)new SendSmsMessageResult.Success());
		}
	}
}
