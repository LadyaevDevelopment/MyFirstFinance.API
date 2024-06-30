using Api.Communication;
using Api.Responses;
using Core.Common.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Api.Authentication
{
	public class DefaultApiAuthenticationHandler(
		IOptionsMonitor<DefaultApiAuthenticationOptions> options,
		ILoggerFactory logger,
		UrlEncoder encoder,
		ISystemClock clock,
		IOptions<MvcNewtonsoftJsonOptions> serializerOptions,
		ITokenProcessor tokenProcessor) : AuthenticationHandler<DefaultApiAuthenticationOptions>(options, logger, encoder, clock)
	{
		private readonly JsonSerializerSettings serializerSettings = serializerOptions.Value.SerializerSettings;

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			string? token = null;
			if (Request.Headers.TryGetValue("Authorization", out StringValues value))
			{
				token = value.ToString();
				if (token.StartsWith("Bearer "))
				{
					token = token[7..];
				}
			}

			if (token is null)
			{
				return AuthenticateResult.NoResult();
			}
			var userModel = await tokenProcessor.UserByToken(token);
			if (userModel is null)
			{
				return AuthenticateResult.Fail("Incorrect token");
			}
			if (userModel.IsBlocked)
			{
				return AuthenticateResult.Fail("Client is blocked");
			}
			return AuthenticateResult.Success(new AuthenticationTicket(
				new ClaimsPrincipal(new ApiClientIdentity(userModel)),
				DefaultApiAuthenticationOptions.DefaultScheme));
		}

		protected override Task HandleChallengeAsync(AuthenticationProperties properties)
		{
			return HandleForbiddenAsync(properties);
		}

		protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
		{
			Response.StatusCode = 403;
			await Response.WriteAsync(JsonConvert.SerializeObject(
				new ResponseWrapper<EmptyResponse>(OperationStatus.Forbidden),
				serializerSettings));
		}
	}
}
