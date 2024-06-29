namespace Domain.Entities.Misc
{
    public record Configuration(
        int ConfirmationCodeLength,
        int ConfirmationCodeLifeTimeInSeconds,
        int UserTemporaryBlockingTimeInSeconds,
        int AllowedFailedCodeConfirmationAttemptCount,
        int ResendConfirmationCodeTimeInSeconds,
        int MinUserAge,
        int PinCodeLength);
}
