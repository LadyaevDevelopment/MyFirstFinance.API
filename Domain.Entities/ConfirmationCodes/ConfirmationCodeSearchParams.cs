namespace Domain.Entities.ConfirmationCodes
{
	public record ConfirmationCodeSearchParams
	{
		public Guid? UserId { get; set; }

		public ConfirmationCodeStatus? Status { get; set; }
	}
}
