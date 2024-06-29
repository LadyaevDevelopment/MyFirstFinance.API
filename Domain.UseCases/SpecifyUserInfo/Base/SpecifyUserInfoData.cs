using Domain.Entities.Users;

namespace Domain.UseCases.SpecifyUserInfo.Base
{
    public record SpecifyUserInfoData(
        bool AllDataProvided,
        ProvisioningUserDataStep? NextStep,
        int? PinCodeLength);
}
