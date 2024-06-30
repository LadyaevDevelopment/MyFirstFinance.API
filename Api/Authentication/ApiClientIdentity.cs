using Core.Common.Authentication;
using System.Security.Claims;

namespace Api.Authentication
{
	public class ApiClientIdentity(
		AuthorizedUserModel userData,
		string authenticationType = "Default") : ClaimsIdentity(GetClientClaims(userData), authenticationType)
	{
		public AuthorizedUserModel ClientData { get; set; } = userData;

		private static List<Claim> GetClientClaims(AuthorizedUserModel? userData)
		{
			return [];
			//if (userData == null || userData.IsBlocked)
			//{
			//	return [];
			//}
			//var result = new List<Claim>
			//{
			//	new(ClaimTypes.Name, userData.Name),
			//};
			//return result;
		}
	}
}