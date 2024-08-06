using Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Api.Responses.Confirmation
{
	public class VerifyConfirmationCodeResponse(string userId, string accessToken, UserStatus userStatus)
	{
		public string UserId { get; set; } = userId;

		[Required]
		public string AccessToken { get; set; } = accessToken;

		public UserStatus UserStatus { get; set; } = userStatus;
	}
}
