using Api.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
	public static class ControllerExtensions
	{
		public static TEntity? ApiUser<TEntity>(this ControllerBase controller) where TEntity : class
		{
			return ((controller?.User?.Identity as ApiClientIdentity)?.ClientData as ApiUserModel<TEntity>)?.Entity;
		}

		public static ApiUserModel? ApiUser(this ControllerBase controller)
		{
			return (controller?.User?.Identity as ApiClientIdentity)?.ClientData;
		}
	}
}
