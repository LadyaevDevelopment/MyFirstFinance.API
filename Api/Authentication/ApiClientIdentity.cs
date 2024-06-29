using System.Security.Claims;

namespace Api.Authentication
{
	public class ApiClientIdentity(
		ApiUserModel userData,
		string authenticationType = "Default") : ClaimsIdentity(GetClientClaims(userData), authenticationType)
	{
		public ApiUserModel ClientData { get; set; } = userData;

		private static List<Claim> GetClientClaims(ApiUserModel? userData)
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