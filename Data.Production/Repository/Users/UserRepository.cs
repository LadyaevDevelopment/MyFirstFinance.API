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
			if (searchParams.PhoneNumber != null)
			{
				items = items.Where(item => item.PhoneNumber == searchParams.PhoneNumber);
			}
			return items;
		}

		protected override IQueryable<UserModel> BuildDependencies(IQueryable<UserModel> items)
		{
			return items.Include(item => item.UserTemporaryBans);
		}

		protected override Expression<Func<UserModel, Guid>> IdByDbModelExpression() => item => item.Id;

		protected override UserEntity ToEntity(UserModel model) => model.ToEntity();

		protected override UserModel ToModel(UserEntity entity) => entity.ToModel();

		public async Task<UserTemporaryBan> SavedTemporaryBan(UserTemporaryBan itemToSave)
		{
			var modelToSave = itemToSave.ToModel();
			var existingItem = await DbContext.UserTemporaryBans.FirstOrDefaultAsync(item => item.Id == modelToSave.Id);
			if (existingItem is null)
			{
				DbContext.UserTemporaryBans.Add(modelToSave);
			}
			else
			{
				DbContext.Entry(existingItem).CurrentValues.SetValues(modelToSave);
			}
			await DbContext.SaveChangesAsync();

			return modelToSave.ToEntity();
		}

		public async Task<bool> RemoveTemporaryBanById(Guid id)
		{
			var itemToDelete = await DbContext.UserTemporaryBans.FirstOrDefaultAsync(item => item.Id == id);
			if (itemToDelete != null)
			{
				DbContext.Remove(itemToDelete);
				await DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<UserResidenceAddress> SavedResidenceAddress(UserResidenceAddress itemToSave)
		{
			var modelToSave = itemToSave.ToModel();
			var existingItem = await DbContext.UserResidenceAddresses.FirstOrDefaultAsync(item => item.Id == modelToSave.Id);
			if (existingItem is null)
			{
				DbContext.UserResidenceAddresses.Add(modelToSave);
			}
			else
			{
				DbContext.Entry(existingItem).CurrentValues.SetValues(modelToSave);
			}
			await DbContext.SaveChangesAsync();

			return modelToSave.ToEntity();
		}

		public async Task<bool> RemoveResidenceAddressById(Guid id)
		{
			var itemToDelete = await DbContext.UserResidenceAddresses.FirstOrDefaultAsync(item => item.Id == id);
			if (itemToDelete != null)
			{
				DbContext.Remove(itemToDelete);
				await DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<IdentityDocument> SavedIdentityDocument(IdentityDocument itemToSave)
		{
			var modelToSave = itemToSave.ToModel();
			var existingItem = await DbContext.IdentityDocuments.FirstOrDefaultAsync(item => item.Id == modelToSave.Id);
			if (existingItem is null)
			{
				DbContext.IdentityDocuments.Add(modelToSave);
			}
			else
			{
				DbContext.Entry(existingItem).CurrentValues.SetValues(modelToSave);
			}
			await DbContext.SaveChangesAsync();

			return modelToSave.ToEntity();
		}

		public async Task<bool> RemoveIdentityDocumentById(Guid id)
		{
			var itemToDelete = await DbContext.IdentityDocuments.FirstOrDefaultAsync(item => item.Id == id);
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
