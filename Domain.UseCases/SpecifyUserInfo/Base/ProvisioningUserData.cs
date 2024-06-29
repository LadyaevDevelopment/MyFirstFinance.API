using Domain.Entities.Users;

namespace Domain.UseCases.SpecifyUserInfo.Base
{
	public abstract class ProvisioningUserData
	{
		public abstract ProvisioningUserDataStep? NextStep(User user);

		public class Base : ProvisioningUserData
		{
			public override ProvisioningUserDataStep? NextStep(User user)
			{
				return user switch
				{
					{ BirthDate: null } => ProvisioningUserDataStep.BirthDate,
					{ LastName: null } => ProvisioningUserDataStep.Name,
					{ Email: null } => ProvisioningUserDataStep.Email,
					{ UserResidenceAddress : null } => ProvisioningUserDataStep.ResidenceAddress,
					{ PinCode: null } => ProvisioningUserDataStep.PinCode,
					{ IdentityDocument : null } => ProvisioningUserDataStep.IdentityDocument,
					_ => null
				};
			}
		}
	}
}
