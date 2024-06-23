namespace Domain.Repository
{
	public interface IRepository<TEntity, TSearchParams> where TEntity : class where TSearchParams : class
	{
		Task<TEntity?> EntityById(Guid id);
		Task<List<TEntity>> FilteredEntities(TSearchParams searchParams);
		Task<TEntity> SavedEntity(TEntity entityToSave);
		Task<List<TEntity>> SavedEntities(List<TEntity> entitiesToSave);
		Task<bool> RemoveById(Guid id);
		Task<bool> RemoveById(List<Guid> ids);
		Task<bool> RemoveByFilter(TSearchParams searchParams);
	}
}
