using Domain.Entities.Users;

namespace Domain.UseCases.SpecifyUserInfo.Base
{
    public abstract class UserStatusStrategy
	{
		public abstract UserStatus ActualStatus(User user);

		public class Base : UserStatusStrategy
		{
			public override UserStatus ActualStatus(User user)
			{
				return user switch
				{
					{ BirthDate: null } => UserStatus.NeedToSpecifyBirthDate,
					{ LastName: null } => UserStatus.NeedToSpecifyName,
					{ Email: null } => UserStatus.NeedToSpecifyEmail,
					{ UserResidenceAddress : null } => UserStatus.NeedToSpecifyResidenceAddress,
					{ PinCode: null } => UserStatus.NeedToCreatePinCode,
					{ IdentityDocument : null } => UserStatus.NeedToSpecifyIdentityDocument,
					_ => UserStatus.Registered
				};
			}
		}
	}
}
