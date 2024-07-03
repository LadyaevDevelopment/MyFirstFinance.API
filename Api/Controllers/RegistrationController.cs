using Api.Communication;
using Api.Extensions;
using Api.Models;
using Api.Requests.Registration;
using Api.Responses.Registration;
using Domain.UseCases.SpecifyUserData.SpecifyBirthDate;
using Domain.UseCases.SpecifyUserInfo.Base;
using Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument;
using Domain.UseCases.SpecifyUserInfo.SpecifyEmail;
using Domain.UseCases.SpecifyUserInfo.SpecifyIdentityDocument;
using Domain.UseCases.SpecifyUserInfo.SpecifyName;
using Domain.UseCases.SpecifyUserInfo.SpecifyPinCode;
using Domain.UseCases.SpecifyUserInfo.SpecifyResidenceAddress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class RegistrationController(
		SpecifyBirthDateUseCase specifyBirthDateUseCase,
		SpecifyNameUseCase specifyNameUseCase,
		SpecifyEmailUseCase specifyEmailUseCase,
		SpecifyResidenceAddressUseCase specifyResidenceAddressUseCase,
		SpecifyPinCodeUseCase specifyPinCodeUseCase,
		SpecifyIdentityDocumentUseCase specifyIdentityDocumentUseCase,
		SkipProvisioningIdentityDocumentUseCase skipProvisioningIdentityDocumentUseCase) : ControllerBase
	{
		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateApiError>> SpecifyBirthDate(
			SpecifyBirthDateRequest request)
		{
			var userId = this.User()!.Id;

			var result = await specifyBirthDateUseCase.Process(userId, request.Date);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateApiError>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SpecifyBirthDateErrorType.AlreadySpecified =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: "Already specified"),
					SpecifyBirthDateErrorType.UserIsMinor =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyBirthDateApiError(SpecifyBirthDateApiErrorType.UserIsMinor),
							errorMessage: null),
					SpecifyBirthDateErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					SpecifyBirthDateErrorType.InvalidData =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyBirthDateApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyBirthDateApiError(SpecifyBirthDateApiErrorType.InvalidData),
							errorMessage: null),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>> SpecifyName(
			SpecifyNameRequest request)
		{
			var userId = this.User()!.Id;

			var result = await specifyNameUseCase.Process(userId, request.LastName, request.FirstName, request.MiddleName);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SpecifyUserInfoErrorType.AlreadySpecified =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: "Already specified"),
					SpecifyUserInfoErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					SpecifyUserInfoErrorType.InvalidData =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyUserInfoApiError(SpecifyUserInfoApiErrorType.InvalidData),
							errorMessage: null),
					SpecifyUserInfoErrorType.Other =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>> SpecifyEmail(
			SpecifyEmailRequest request)
		{
			var userId = this.User()!.Id;

			var result = await specifyEmailUseCase.Process(userId, request.Email);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SpecifyUserInfoErrorType.AlreadySpecified =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: "Already specified"),
					SpecifyUserInfoErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					SpecifyUserInfoErrorType.InvalidData =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyUserInfoApiError(SpecifyUserInfoApiErrorType.InvalidData),
							errorMessage: null),
					SpecifyUserInfoErrorType.Other =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>> SpecifyResidenceAddress(
			SpecifyResidenceAddressRequest request)
		{
			var userId = this.User()!.Id;

			var result = await specifyResidenceAddressUseCase.Process(
				userId,
				request.CountryId,
				request.City,
				request.Street,
				request.BuildingNumber,
				request.ApartmentNumber);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SpecifyUserInfoErrorType.AlreadySpecified =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: "Already specified"),
					SpecifyUserInfoErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					SpecifyUserInfoErrorType.InvalidData =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyUserInfoApiError(SpecifyUserInfoApiErrorType.InvalidData),
							errorMessage: null),
					SpecifyUserInfoErrorType.Other =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>> SpecifyPinCode(
			SpecifyPinCodeRequest request)
		{
			var userId = this.User()!.Id;

			var result = await specifyPinCodeUseCase.Process(userId, request.PinCode);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SpecifyUserInfoErrorType.AlreadySpecified =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: "Already specified"),
					SpecifyUserInfoErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					SpecifyUserInfoErrorType.InvalidData =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyUserInfoApiError(SpecifyUserInfoApiErrorType.InvalidData),
							errorMessage: null),
					SpecifyUserInfoErrorType.Other =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>> SpecifyIdentityDocument(
			SpecifyIdentityDocumentRequest request)
		{
			var userId = this.User()!.Id;

			var result = await specifyIdentityDocumentUseCase.Process(userId, request.DocumentBytes);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SpecifyUserInfoErrorType.AlreadySpecified =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: "Already specified"),
					SpecifyUserInfoErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					SpecifyUserInfoErrorType.InvalidData =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.InvalidRequest,
							error: new SpecifyUserInfoApiError(SpecifyUserInfoApiErrorType.InvalidData),
							errorMessage: null),
					SpecifyUserInfoErrorType.Other =>
						new ResponseWrapper<SpecifyUserDataResponse, SpecifyUserInfoApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPut("[action]")]
		public async Task<ResponseWrapper<SpecifyUserDataResponse>> SkipProvisioningIdentityDocument()
		{
			var userId = this.User()!.Id;

			var result = await skipProvisioningIdentityDocumentUseCase.Process(userId);
			if (result.Successful)
			{
				return new ResponseWrapper<SpecifyUserDataResponse>(
					new SpecifyUserDataResponse(
						result.Data!.AllDataProvided,
						result.Data!.NextStep?.ToApiEnum()));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					SkipProvisioningIdentityDocumentErrorType.UserNotFound =>
						new ResponseWrapper<SpecifyUserDataResponse>(
							OperationStatus.NotFound,
							errorMessage: null),
					SkipProvisioningIdentityDocumentErrorType.Other =>
						new ResponseWrapper<SpecifyUserDataResponse>(
							OperationStatus.Failed,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}
	}
}
