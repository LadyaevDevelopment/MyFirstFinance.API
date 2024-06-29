namespace Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument
{
	public record SkipProvisioningIdentityDocumentError(
		SkipProvisioningIdentityDocumentErrorType ErrorType,
		string? ErrorMessage);
}
