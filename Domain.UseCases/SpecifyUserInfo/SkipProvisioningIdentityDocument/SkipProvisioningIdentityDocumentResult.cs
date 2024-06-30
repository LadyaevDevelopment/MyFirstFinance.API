using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserInfo.SkipProvisioningIdentityDocument
{
	public class SkipProvisioningIdentityDocumentResult
	{
		public bool Successful { get; }

		public SpecifyUserInfoData? Data { get; }

		public SkipProvisioningIdentityDocumentError? Error { get; }

		private SkipProvisioningIdentityDocumentResult(
			bool successful,
			SpecifyUserInfoData? data,
			SkipProvisioningIdentityDocumentError? error)
		{
			Successful = successful;
			Data = data;
			Error = error;
		}

		public class Success(SpecifyUserInfoData data) : SkipProvisioningIdentityDocumentResult(true, data, null);

		public class Failure(SkipProvisioningIdentityDocumentError error) : SkipProvisioningIdentityDocumentResult(false, null, error);
	}
}
