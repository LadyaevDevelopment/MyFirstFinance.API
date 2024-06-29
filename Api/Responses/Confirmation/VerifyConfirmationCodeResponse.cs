using Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Api.Responses.Confirmation
{
	public class VerifyConfirmationCodeResponse(Guid userId, string accessToken, UserStatus userStatus)
	{
		public Guid UserId { get; set; } = userId;

		[Required]
		public string AccessToken { get; set; } = accessToken;

		public UserStatus UserStatus { get; set; } = userStatus;
	}
}
