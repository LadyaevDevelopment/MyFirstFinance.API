using Domain.Entities.Users;

namespace Api.Models
{
	public enum ApiProvisioningUserDataStep
	{
		BirthDate = 1,
		Name = 2,
		Email = 3,
		ResidenceAddress = 4,
		PinCode = 5,
		IdentityDocument = 6,
	}

	public static class ProvisioningUserDataStepExtensions
	{
		public static ApiProvisioningUserDataStep ToApiEnum(this ProvisioningUserDataStep step)
		{
			return step switch
			{
				ProvisioningUserDataStep.BirthDate => ApiProvisioningUserDataStep.BirthDate,
				ProvisioningUserDataStep.Name => ApiProvisioningUserDataStep.Name,
				ProvisioningUserDataStep.Email => ApiProvisioningUserDataStep.Email,
				ProvisioningUserDataStep.ResidenceAddress => ApiProvisioningUserDataStep.ResidenceAddress,
				ProvisioningUserDataStep.PinCode => ApiProvisioningUserDataStep.PinCode,
				ProvisioningUserDataStep.IdentityDocument => ApiProvisioningUserDataStep.IdentityDocument,
				_ => throw new NotImplementedException(),
			};
		}
	}
}
