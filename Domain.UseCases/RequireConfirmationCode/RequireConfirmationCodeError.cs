﻿namespace Domain.UseCases.RequireConfirmationCode
{
	public record RequireConfirmationCodeError(
		RequireConfirmationCodeErrorType ErrorType,
		int? RemainingTemporaryBlockingTimeInSeconds,
		Exception? Exception);
}
