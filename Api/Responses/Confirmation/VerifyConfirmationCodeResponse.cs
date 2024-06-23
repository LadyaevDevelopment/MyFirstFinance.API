using Domain.Entities.Users;

namespace Api.Responses.Confirmation
{
	public class VerifyConfirmationCodeResponse(Guid userId, string accessToken, UserStatus userStatus)
	{
		public Guid UserId { get; set; } = userId;

		public string AccessToken { get; set; } = accessToken;

		public UserStatus UserStatus { get; set; } = userStatus;
	}
}
