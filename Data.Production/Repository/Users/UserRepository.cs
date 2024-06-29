using Data.Production.Context;
using Data.Production.Mapping;
using Domain.Entities.Users;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserEntity = Domain.Entities.Users.User;
using UserModel = Data.Production.Models.User;

namespace Data.Production.Repository.Users
{
	public class UserRepository : RepositoryAbstract<UserEntity, UserModel, UserSearchParams>, IUserRepository
	{
		public UserRepository(DefaultDbContext dbContext) : base(dbContext)
		{
		}

		protected override IQueryable<UserModel> BuildFilterQuery(IQueryable<UserModel> items, UserSearchParams searchParams)
		{
			return items;
		}

		protected override IQueryable<UserModel> BuildDependencies(IQueryable<UserModel> items)
		{
			return items.Include(item => item.UserTemporaryBans);
		}

		protected override Expression<Func<UserModel, Guid>> IdByDbModelExpression() => item => item.Id;

		protected override UserEntity ToEntity(UserModel model) => model.ToEntity();

		protected override UserModel ToModel(UserEntity entity) => entity.ToModel();

		public async Task<UserTemporaryBan> SavedTemporaryBan(UserTemporaryBan item)
		{
			var dbModel = item.ToModel();
			DbContext.UserTemporaryBans.Add(dbModel);
			await DbContext.SaveChangesAsync();
			return dbModel.ToEntity();
		}

		public async Task<bool> RemoveBanById(Guid id)
		{
			var itemToDelete = DbContext.UserTemporaryBans.FirstOrDefault(item => item.Id == id);
			if (itemToDelete != null)
			{
				DbContext.Remove(itemToDelete);
				await DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
