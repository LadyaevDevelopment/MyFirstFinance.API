namespace Domain.UseCases.SpecifyUserData.SpecifyBirthDate
{
    public enum SpecifyBirthDateErrorType
    {
        AlreadySpecified = 1,
        UserIsMinor = 2,
        UserNotFound = 3,
        InvalidData = 4,
    }
}
