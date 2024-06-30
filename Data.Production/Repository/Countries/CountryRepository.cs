using Data.Production.Context;
using Data.Production.Mapping;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CountryEntity = Domain.Entities.Countries.Country;
using CountryModel = Data.Production.Models.Country;

namespace Data.Production.Repository.Countries
{
	public class CountryRepository : RepositoryAbstract<CountryEntity, CountryModel, object>, ICountryRepository
	{
		public CountryRepository(DefaultDbContext dbContext) : base(dbContext)
		{
		}

		protected override IQueryable<CountryModel> BuildFilterQuery(
			IQueryable<CountryModel> items,
			object searchParams) => items;

		protected override IQueryable<CountryModel> BuildDependencies(IQueryable<CountryModel> items)
		{
			return items.Include(item => item.CountryPhoneNumberMasks);
		}

		protected override bool NeedToConfigureAfterSaving => true;

		protected override async Task ConfigureAfterSaving(CountryModel model)
		{
			var existingItems = await DbContext.CountryPhoneNumberMasks.Where(item => item.CountryId == model.Id).ToListAsync();
			DbContext.RemoveRange(existingItems);

			foreach (var item in model.CountryPhoneNumberMasks)
			{
				item.CountryId = model.Id;
				DbContext.CountryPhoneNumberMasks.Add(item);
			}
		}

		protected override Expression<Func<CountryModel, Guid>> IdByDbModelExpression() => item => item.Id;

		protected override CountryEntity ToEntity(CountryModel model) => model.ToEntity();

		protected override CountryModel ToModel(CountryEntity entity) => entity.ToModel();
	}
}
