using Domain.Services.SmsService;

namespace Core.SmsService
{
	public class SmsRuService : ISmsService
	{
		public Task<SendSmsMessageResult> SendSmsMessage(string phoneNumber, string message)
		{
			return Task.FromResult((SendSmsMessageResult)new SendSmsMessageResult.Success());
		}
	}
}
