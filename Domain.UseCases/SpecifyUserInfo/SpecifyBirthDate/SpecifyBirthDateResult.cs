using Domain.UseCases.SpecifyUserInfo.Base;

namespace Domain.UseCases.SpecifyUserData.SpecifyBirthDate
{
    public class SpecifyBirthDateResult
    {
        public bool Successful { get; }

        public SpecifyUserInfoData? Data { get; }

        public SpecifyBirthDateError? Error { get; }

        private SpecifyBirthDateResult(bool successful, SpecifyUserInfoData? data, SpecifyBirthDateError? error)
        {
            Successful = successful;
            Data = data;
            Error = error;
        }

        public class Success(SpecifyUserInfoData data) : SpecifyBirthDateResult(true, data, null);

        public class Failure(SpecifyBirthDateError error) : SpecifyBirthDateResult(false, null, error);
    }
}
