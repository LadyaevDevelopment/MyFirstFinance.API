using Api.Communication;
using Api.Requests.Confirmation;
using Api.Responses.Confirmation;
using Core.Common.Authentication;
using Domain.Repository;
using Domain.UseCases.RequireConfirmationCode;
using Domain.UseCases.VerifyConfirmationCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[AllowAnonymous]
	public class ConfirmationController(
		RequireConfirmationCodeUseCase requireConfirmationCodeUseCase,
		VerifyConfirmationCodeUseCase verifyConfirmationCodeUseCase,
		IUserRepository userRepository,
		ITokenProcessor tokenProcessor) : ControllerBase
	{
		[HttpPost("[action]")]
		public async Task<ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeApiError>> RequireConfirmationCode(
			RequireConfirmationCodeRequest request)
		{
			var result = await requireConfirmationCodeUseCase.Process(request.CountryPhoneCode, request.PhoneNumber);
			if (result.Successful)
			{
				return new ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeApiError>(
					new RequireConfirmationCodeResponse(
						result.Data!.ConfirmationCodeId,
						result.Data!.ConfirmationCodeLength,
						result.Data!.ResendTimeInSeconds,
						result.Data!.AllowedConfirmCodeAttemptCount,
						result.Data.ConfirmationCodeLifeTimeInSeconds));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					RequireConfirmationCodeErrorType.UserBlocked =>
						new ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeApiError>(
							OperationStatus.Forbidden,
							new RequireConfirmationCodeApiError(
								RequireConfirmationCodeApiErrorType.UserBlocked,
								result.Error!.RemainingTemporaryBlockingTimeInSeconds!),
							errorMessage: null),
					RequireConfirmationCodeErrorType.UserTemporaryBlocked =>
						new ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeApiError>(
							OperationStatus.Forbidden,
							new RequireConfirmationCodeApiError(
								RequireConfirmationCodeApiErrorType.UserTemporaryBlocked,
								result.Error!.RemainingTemporaryBlockingTimeInSeconds!),
							errorMessage: null),
					RequireConfirmationCodeErrorType.ConfirmationCodeAlreadySent =>
						new ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeApiError>(
							OperationStatus.TooManyRequests,
							error: null,
							errorMessage: null),
					RequireConfirmationCodeErrorType.Other =>
						new ResponseWrapper<RequireConfirmationCodeResponse, RequireConfirmationCodeApiError>(
							OperationStatus.Failed,
							error: null,
							result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}

		[HttpPost("[action]")]
		public async Task<ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>> VerifyConfirmationCode(
			VerifyConfirmationCodeRequest request)
		{
			var result = await verifyConfirmationCodeUseCase.Process(request.ConfirmationCodeId, request.ConfirmationCode);

			if (result.Successful)
			{
				var token = tokenProcessor.TokenById(result.Data!.UserId);
				var user = (await userRepository.EntityById(result.Data!.UserId))!;

				return new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>(
					new VerifyConfirmationCodeResponse(
						result.Data!.UserId,
						token,
						user.Status));
			}
			else
			{
				return result.Error!.ErrorType switch
				{
					VerifyConfirmationCodeErrorType.CodeNotFound =>
						new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>(
							OperationStatus.NotFound,
							error: null,
							errorMessage: null),
					VerifyConfirmationCodeErrorType.WrongCode =>
						new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>(
							OperationStatus.InvalidRequest,
							error: new VerifyConfirmationCodeApiError(
								VerifyConfirmationCodeApiErrorType.WrongCode,
								temporaryBlockingTimeInSeconds: null),
							errorMessage: null),
					VerifyConfirmationCodeErrorType.CodeLifeTimeExpired =>
						new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>(
							OperationStatus.Failed,
							error: new VerifyConfirmationCodeApiError(
								VerifyConfirmationCodeApiErrorType.CodeLifeTimeExpired,
								temporaryBlockingTimeInSeconds: null),
							errorMessage: null),
					VerifyConfirmationCodeErrorType.FailedCodeConfirmationAttemptCountExceeded =>
						new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>(
							OperationStatus.Failed,
							error: new VerifyConfirmationCodeApiError(
								VerifyConfirmationCodeApiErrorType.FailedCodeConfirmationAttemptCountExceeded,
								temporaryBlockingTimeInSeconds: result.Error!.TemporaryBlockingTimeInSeconds),
							errorMessage: null),
					VerifyConfirmationCodeErrorType.Other =>
						new ResponseWrapper<VerifyConfirmationCodeResponse, VerifyConfirmationCodeApiError>(
							OperationStatus.Failed,
							error: null,
							errorMessage: result.Error!.Exception?.Message),
					_ => throw new NotImplementedException(),
				};
			}
		}
	}
}
