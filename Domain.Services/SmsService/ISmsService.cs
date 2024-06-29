namespace Domain.Services.SmsService
{
	public interface ISmsService
	{
		Task<SendSmsMessageResult> SendSmsMessage(string phoneNumber, string message);
	}
}
