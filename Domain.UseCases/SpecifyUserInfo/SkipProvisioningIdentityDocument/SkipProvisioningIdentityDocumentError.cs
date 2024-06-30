namespace Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument
{
	public record SkipProvisioningIdentityDocumentError(
		SkipProvisioningIdentityDocumentErrorType ErrorType,
		Exception? Exception);
}
