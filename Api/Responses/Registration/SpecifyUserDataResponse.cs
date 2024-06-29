using Api.Models;

namespace Api.Responses.Registration
{
	public class SpecifyUserDataResponse(bool allDataProvided, ApiProvisioningUserDataStep? nextStep)
	{
		public bool AllDataProvided { get; set; } = allDataProvided;

		public ApiProvisioningUserDataStep? NextStep { get; set; } = nextStep;

		public int? PinCodeLength { get; set; }
	}
}
