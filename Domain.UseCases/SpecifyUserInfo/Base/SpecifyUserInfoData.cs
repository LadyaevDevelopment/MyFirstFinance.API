using Domain.Entities.Users;

namespace Domain.UseCases.SpecifyUserInfo.Base
{
    public record SpecifyUserInfoData(
        UserStatus ActualStatus,
        int? PinCodeLength);
}
