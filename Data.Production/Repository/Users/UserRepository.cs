using Data.Production.Context;
using Data.Production.Mapping;
using Domain.Entities.Users;
using Domain.Repository;
using System.Linq.Expressions;
using UserEntity = Domain.Entities.Users.User;
using UserModel = Data.Production.Models.User;

namespace Data.Production.Repository.Users
{
	public class UserRepository(DefaultDbContext dbContext) : RepositoryAbstract<UserEntity, UserModel, UserSearchParams>(dbContext), IUserRepository
	{
		protected override IQueryable<UserModel> BuildFilterQuery(IQueryable<UserModel> items, UserSearchParams searchParams)
		{
			return items;
		}

		protected override Expression<Func<UserModel, Guid>> IdByDbModelExpression() => item => item.Id;

		protected override UserEntity ToEntity(UserModel model) => model.ToEntity();

		protected override UserModel ToModel(UserEntity entity) => entity.ToModel();
	}
}
