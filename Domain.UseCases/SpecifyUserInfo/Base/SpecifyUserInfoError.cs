namespace Domain.UseCases.SpecifyUserInfo.Base
{
	public record SpecifyUserInfoError(
		SpecifyUserInfoErrorType ErrorType,
		Exception? Exception);
}
