using Data.Production.Context;
using Data.Production.Mapping;
using Domain.Entities.Users;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Production.Repository.Users
{
	public class UserRepository(DefaultDbContext dbContext) : IUserRepository
	{
		public async Task<User?> EntityById(Guid id)
		{
			var item = await dbContext.Users.FirstOrDefaultAsync(item => item.Id == id);
			return item?.ToEntity();
		}

		public async Task<List<User>> FilteredEntities(UserSearchParams searchParams)
		{
			var items = await dbContext.Users.ToListAsync();
			return items.Select(item => item.ToEntity()).ToList();
		}

		public async Task<bool> RemoveByFilter(UserSearchParams searchParams)
		{
			var query = await dbContext.Users.ToListAsync();
			if (query.Count != 0)
			{
				dbContext.RemoveRange(query);
				await dbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> RemoveById(Guid id)
		{
			var item = await dbContext.Users.FirstOrDefaultAsync(item => item.Id == id);
			if (item != null)
			{
				dbContext.Remove(item);
				await dbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> RemoveById(List<Guid> ids)
		{
			var itemsToDelete = await dbContext.Users
				.Where(item => ids.Contains(item.Id))
				.ToListAsync();
			if (itemsToDelete.Count != 0)
			{
				dbContext.RemoveRange(itemsToDelete);
				await dbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<User>> SavedEntities(List<User> entitiesToSave)
		{
			var savedItems = entitiesToSave.Select(item => item.ToModel());
			foreach (var item in savedItems)
			{
				var existingItem = await dbContext.Users.FindAsync(item.Id);
				if (existingItem != null)
				{
					dbContext.Entry(existingItem).CurrentValues.SetValues(item);
				}
				else
				{
					dbContext.Users.Add(item);
				}
			}
			await dbContext.SaveChangesAsync();

			return savedItems.Select(item => item.ToEntity()).ToList();
		}

		public async Task<User> SavedEntity(User entityToSave)
		{
			var savedItem = entityToSave.ToModel();

			var existingItem = await dbContext.Users.FindAsync(savedItem.Id);
			if (existingItem != null)
			{
				dbContext.Entry(existingItem).CurrentValues.SetValues(savedItem);
			}
			else
			{
				dbContext.Users.Add(savedItem);
			}

			await dbContext.SaveChangesAsync();

			return savedItem.ToEntity();
		}
	}
}
