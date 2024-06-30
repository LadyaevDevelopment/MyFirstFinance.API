using Data.Production.Context;
using Data.Production.Mapping;
using Domain.Entities.ConfirmationCodes;
using Domain.Repository;
using System.Linq.Expressions;
using ConfirmationCodeEntity = Domain.Entities.ConfirmationCodes.ConfirmationCode;
using ConfirmationCodeModel = Data.Production.Models.ConfirmationCode;

namespace Data.Production.Repository.ConfirmationCodes
{
	public class ConfirmationCodeRepository : RepositoryAbstract<ConfirmationCodeEntity, ConfirmationCodeModel, ConfirmationCodeSearchParams>, IConfirmationCodeRepository
	{
		public ConfirmationCodeRepository(DefaultDbContext dbContext) : base(dbContext)
		{
		}

		protected override IQueryable<ConfirmationCodeModel> BuildFilterQuery(
			IQueryable<ConfirmationCodeModel> items,
			ConfirmationCodeSearchParams searchParams){
			if (searchParams.UserId != null)
			{
				items = items.Where(item => item.UserId == searchParams.UserId);
			}
			if (searchParams.Status != null)
			{
				items = items.Where(item => item.StatusId == (int)searchParams.Status);
			}
			return items;
		}

		protected override IQueryable<ConfirmationCodeModel> BuildDependencies(IQueryable<ConfirmationCodeModel> items) => items;

		protected override bool NeedToConfigureAfterSaving => false;

		protected override Expression<Func<ConfirmationCodeModel, Guid>> IdByDbModelExpression() => item => item.Id;

		protected override ConfirmationCodeEntity ToEntity(ConfirmationCodeModel model) => model.ToEntity();

		protected override ConfirmationCodeModel ToModel(ConfirmationCodeEntity entity) => entity.ToModel();
	}
}
