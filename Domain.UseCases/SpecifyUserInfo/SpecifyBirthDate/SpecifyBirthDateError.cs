namespace Domain.UseCases.SpecifyUserData.SpecifyBirthDate
{
    public record SpecifyBirthDateError(
        SpecifyBirthDateErrorType ErrorType,
        string? ErrorMessage);
}
