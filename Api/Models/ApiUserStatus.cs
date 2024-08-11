using Domain.Entities.Users;

namespace Api.Models
{
    public enum ApiUserStatus
    {
        NeedToSpecifyBirthDate = 1,
		NeedToSpecifyName = 2,
		NeedToSpecifyEmail = 3,
		NeedToSpecifyResidenceAddress = 4,
		NeedToCreatePinCode = 5,
		NeedToSpecifyIdentityDocument = 6,
		Registered = 7,
    }

    public static class UserStatusExtensions
    {
        public static ApiUserStatus ToApiEnum(this UserStatus step)
        {
            return step switch
            {
                UserStatus.NeedToSpecifyBirthDate => ApiUserStatus.NeedToSpecifyBirthDate,
                UserStatus.NeedToSpecifyName => ApiUserStatus.NeedToSpecifyName,
                UserStatus.NeedToSpecifyEmail => ApiUserStatus.NeedToSpecifyEmail,
                UserStatus.NeedToSpecifyResidenceAddress => ApiUserStatus.NeedToSpecifyResidenceAddress,
                UserStatus.NeedToCreatePinCode => ApiUserStatus.NeedToCreatePinCode,
                UserStatus.NeedToSpecifyIdentityDocument => ApiUserStatus.NeedToSpecifyIdentityDocument,
                UserStatus.Registered => ApiUserStatus.Registered,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
