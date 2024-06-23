namespace Domain.Entities.Users
{
	public enum UserStatus
	{
		NeedToSpecifyBirthDate = 1,
		NeedToSpecifyName = 2,
		NeedToSpecifyEmail = 3,
		NeedToSpecifyResidenceAddress = 4,
		NeedToCreatePinCode = 5,
		NeedToSpecifyIdentityDocument = 6,
		Registered = 7,
	}
}
