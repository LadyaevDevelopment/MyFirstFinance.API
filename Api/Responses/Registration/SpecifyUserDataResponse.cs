using Api.Models;

namespace Api.Responses.Registration
{
    public class SpecifyUserDataResponse(ApiUserStatus userStatus)
	{
		public ApiUserStatus UserStatus { get; set; } = userStatus;

		public int? PinCodeLength { get; set; }
	}
}
