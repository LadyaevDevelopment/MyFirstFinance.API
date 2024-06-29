using Domain.Entities.ConfirmationCodes;

namespace Domain.Repository
{
	public interface IConfirmationCodeRepository : IRepository<ConfirmationCode, ConfirmationCodeSearchParams>
	{
	}
}
