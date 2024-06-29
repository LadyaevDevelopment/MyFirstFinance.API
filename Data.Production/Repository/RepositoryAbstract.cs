using Data.Production.Context;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.Production.Repository
{
	public abstract class RepositoryAbstract<TEntity, TDbModel, TSearchParams> : IRepository<TEntity, TSearchParams>
		where TEntity : class where TSearchParams : class where TDbModel : class
	{
		protected DefaultDbContext DbContext { get; }

		public RepositoryAbstract(DefaultDbContext dbContext)
		{
			DbContext = dbContext;
		}

		protected abstract TEntity ToEntity(TDbModel model);

		protected abstract TDbModel ToModel(TEntity entity);
		
		protected abstract IQueryable<TDbModel> BuildFilterQuery(IQueryable<TDbModel> items, TSearchParams searchParams);

		protected virtual IQueryable<TDbModel> BuildDependencies(IQueryable<TDbModel> items) => items;

		protected abstract Expression<Func<TDbModel, Guid>> IdByDbModelExpression();

		protected Guid IdByModel(TDbModel entity)
		{
			return IdByDbModelExpression().Compile()(entity);
		}

		protected MemberInfo? DbModelIdMember()
		{
			return (IdByDbModelExpression().Body as MemberExpression)?.Member;
		}

		protected Expression<Func<TDbModel, bool>> FilterDbModelByIdExpression(Guid id)
		{
			var parameter = Expression.Parameter(typeof(TDbModel), "model");
			var property = Expression.MakeMemberAccess(parameter, DbModelIdMember()!);
			var constant = Expression.Constant(id);
			var equalsCall = Expression.Equal(property, constant);
			return Expression.Lambda<Func<TDbModel, bool>>(equalsCall, parameter);
		}

		protected Expression<Func<TDbModel, bool>> FilterDbModelByIdsExpression(List<Guid> ids)
		{
			var parameter = Expression.Parameter(typeof(TDbModel), "item");
			var property = Expression.MakeMemberAccess(parameter, DbModelIdMember()!);
			var containsMethod = typeof(List<Guid>).GetMethod("Contains", [typeof(Guid)])!;
			var containsCall = Expression.Call(Expression.Constant(ids), containsMethod, property);
			return Expression.Lambda<Func<TDbModel, bool>>(containsCall, parameter);
		}

		public async Task<TEntity?> EntityById(Guid id)
		{
			var item = await BuildDependencies(DbContext.Set<TDbModel>().Where(FilterDbModelByIdExpression(id)))
				.FirstOrDefaultAsync();
			return item is null ? null : ToEntity(item);
		}

		public async Task<List<TEntity>> FilteredEntities(TSearchParams searchParams)
		{
			var items = await BuildDependencies(BuildFilterQuery(DbContext.Set<TDbModel>(), searchParams)).ToListAsync();
			return items.Select(ToEntity).ToList();
		}

		public async Task<bool> RemoveByFilter(TSearchParams searchParams)
		{
			var items = await BuildDependencies(BuildFilterQuery(DbContext.Set<TDbModel>(), searchParams)).ToListAsync();
			if (items.Count != 0)
			{
				DbContext.RemoveRange(items);
				await DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> RemoveById(Guid id)
		{
			var item = await DbContext.Set<TDbModel>().Where(FilterDbModelByIdExpression(id)).FirstOrDefaultAsync();
			if (item != null)
			{
				DbContext.Remove(item);
				await DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> RemoveById(List<Guid> ids)
		{
			var itemsToDelete = await DbContext.Set<TDbModel>()
				.Where(FilterDbModelByIdsExpression(ids))
				.ToListAsync();
			if (itemsToDelete.Count != 0)
			{
				DbContext.RemoveRange(itemsToDelete);
				await DbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<TEntity>> SavedEntities(List<TEntity> entitiesToSave)
		{
			var savedItems = entitiesToSave.Select(ToModel);
			foreach (var item in savedItems)
			{
				var existingItem = await EntityById(IdByModel(item));
				if (existingItem != null)
				{
					DbContext.Entry(existingItem).CurrentValues.SetValues(item);
				}
				else
				{
					DbContext.Set<TDbModel>().Add(item);
				}
			}
			await DbContext.SaveChangesAsync();

			return savedItems.Select(ToEntity).ToList();
		}

		public async Task<TEntity> SavedEntity(TEntity entityToSave)
		{
			var savedItem = ToModel(entityToSave);

			var existingItem = await EntityById(IdByModel(savedItem));
			if (existingItem != null)
			{
				DbContext.Entry(existingItem).CurrentValues.SetValues(savedItem);
			}
			else
			{
				DbContext.Set<TDbModel>().Add(savedItem);
			}

			await DbContext.SaveChangesAsync();

			return ToEntity(savedItem);
		}
	}
}
