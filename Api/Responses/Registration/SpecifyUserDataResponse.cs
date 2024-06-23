using Api.Models;

namespace Api.Responses.Registration
{
	public class SpecifyUserDataResponse(bool allDataProvided, ProvisioningUserDataStep? nextStep)
	{
		public bool AllDataProvided { get; set; } = allDataProvided;

		public ProvisioningUserDataStep? NextStep { get; set; } = nextStep;

		public int? PinCodeLength { get; set; }
	}
}
