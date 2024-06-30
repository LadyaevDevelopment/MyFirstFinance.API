namespace Core.Common.SmsService
{
	public interface ISmsService
	{
		Task<SendSmsMessageResult> SendSmsMessage(string phoneNumber, string message);
	}
}
