using Api.Authentication;
using Core.Common.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
	public static class ControllerExtensions
	{
		public static TEntity? ApiUser<TEntity>(this ControllerBase controller) where TEntity : class
		{
			return ((controller?.User?.Identity as ApiClientIdentity)?.ClientData as ApiUserModel<TEntity>)?.Entity;
		}

		public static AuthorizedUserModel? User(this ControllerBase controller)
		{
			return (controller?.User?.Identity as ApiClientIdentity)?.ClientData;
		}
	}
}
