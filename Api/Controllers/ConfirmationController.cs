using Api.Communication;
using Api.Requests.Confirmation;
using Api.Responses.Confirmation;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[AllowAnonymous]
	public class ConfirmationController : ControllerBase
	{
		[HttpPost("[action]")]
		public async Task<ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeError>> RequireConfirmationCode(
			RequireConfirmationCodeRequest request)
		{
			return new ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeError>(
				new RequireConfirmationCodeResponse(Guid.NewGuid(), 5, 120, 3, 600));
		}

		[HttpPost("[action]")]
		public async Task<ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeError>> VerifyConfirmationCode(
			VerifyConfirmationCodeRequest request)
		{
			return new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeError>(
				new VerifyConfirmationCodeResponse(Guid.NewGuid(), "", UserStatus.NeedToSpecifyBirthDate));
		}
	}
}
