using Api.Communication;
using Api.Models;
using Api.Requests.Registration;
using Api.Responses.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class RegistrationController(ILogger<RegistrationController> logger) : ControllerBase
	{
		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateError>> SpecifyBirthDate(
			SpecifyBirthDateRequest request)
		{
			return new ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateError>(
				new SpecifyUserDataResponse(false, ProvisioningUserDataStep.Name));
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SpecifyName(SpecifyNameRequest request)
		{
			return new ResponseWrapper<SpecifyUserDataResponse>(
				new SpecifyUserDataResponse(false, ProvisioningUserDataStep.Email));
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SpecifyEmail(SpecifyEmailRequest request)
		{
			return new ResponseWrapper<SpecifyUserDataResponse>(
				new SpecifyUserDataResponse(false, ProvisioningUserDataStep.ResidenceAddress));
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SpecifyResidenceAddress(SpecifyResidenceAddressRequest request)
		{
			return new ResponseWrapper<SpecifyUserDataResponse>(
				new SpecifyUserDataResponse(false, ProvisioningUserDataStep.PinCode));
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SpecifyPinCode(SpecifyPinCodeRequest request)
		{
			return new ResponseWrapper<SpecifyUserDataResponse>(
				new SpecifyUserDataResponse(false, ProvisioningUserDataStep.IdentityDocument));
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SpecifyIdentityDocument(SpecifyIdentityDocumentRequest request)
		{
			return new ResponseWrapper<SpecifyUserDataResponse>(
				new SpecifyUserDataResponse(true, null));
		}

		[HttpGet("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SkipProvisioningIdentityDocument()
		{
			return new ResponseWrapper<SpecifyUserDataResponse>(
				new SpecifyUserDataResponse(true, null));
		}
	}
}
