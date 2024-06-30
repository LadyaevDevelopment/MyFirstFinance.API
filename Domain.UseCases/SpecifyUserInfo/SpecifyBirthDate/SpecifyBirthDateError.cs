namespace Domain.UseCases.SpecifyUserData.SpecifyBirthDate
{
    public record SpecifyBirthDateError(
        SpecifyBirthDateErrorType ErrorType,
		Exception? Exception);
}
