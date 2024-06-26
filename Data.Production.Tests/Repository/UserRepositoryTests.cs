using Data.Production.Context;
using Data.Production.Mapping;
using Data.Production.Models;
using Data.Production.Repository.Users;
using Data.Production.Tests.Support;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Data.Production.Tests.Repository;

public class UserRepositoryTests
{
	[Fact]
	public async Task EntityById_ShouldReturnUser_WhenUserExists()
	{
        var userId = Guid.NewGuid();
        var users = new List<User>
        {
            new() { Id = userId }
        };

        var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
        dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

        var repository = new UserRepository(dbContextMock.Object);
        var result = await repository.EntityById(userId);

		Assert.NotNull(result);
		Assert.Equal(userId, result.Id);
	}

	[Fact]
	public async Task EntityById_ShouldReturnNull_WhenUserDoesNotExist()
	{
        var userId = Guid.NewGuid();
        var users = new List<User>();

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.EntityById(userId);

		Assert.Null(result);
	}

	[Fact]
	public async Task FilteredEntities_ShouldReturnUsers_WhenUsersExist()
	{
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
        };

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.FilteredEntities(new Domain.Entities.Users.UserSearchParams());

		Assert.NotNull(result);
		Assert.Equal(users.Count, result.Count);
	}

	[Fact]
	public async Task RemoveByFilter_ShouldRemoveUsers_WhenUsersExist()
	{
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
        };

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);
		dbContextMock.Setup(db => db.RemoveRange(It.IsAny<IEnumerable<object>>()))
			.Callback<IEnumerable<object>>(itemsToRemove =>
			{
				var usersToRemove = itemsToRemove.Cast<User>().ToList();
				users.RemoveAll(item => usersToRemove.Contains(item));
			});

        var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.RemoveByFilter(new Domain.Entities.Users.UserSearchParams());

		Assert.True(result);
		Assert.Empty(users);
		dbContextMock.Verify(db => db.RemoveRange(It.IsAny<IEnumerable<User>>()), Times.Once);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task RemoveByFilter_ShouldReturnFalse_WhenNoUsersExist()
	{
        var users = new List<User>().AsQueryable();

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.RemoveByFilter(new Domain.Entities.Users.UserSearchParams());

		Assert.False(result);
		dbContextMock.Verify(db => db.RemoveRange(It.IsAny<IEnumerable<User>>()), Times.Never);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
	}

	[Fact]
	public async Task RemoveById_ShouldRemoveUser_WhenUserExists()
	{
        var userId = Guid.NewGuid();
        var users = new List<User>
        {
            new() { Id = userId },
            new() { Id = new Guid() }
        };

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);
		dbContextMock.Setup(db => db.Remove(It.IsAny<User>()))
            .Callback<User>(userToRemove =>
            {
                users.Remove(userToRemove);
            });

        var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.RemoveById(userId);

		Assert.True(result);
        Assert.Single(users);

		dbContextMock.Verify(db => db.Remove(It.IsAny<User>()), Times.Once);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task RemoveById_ShouldReturnFalse_WhenUserDoesNotExist()
	{
        var userId = Guid.NewGuid();
        var users = new List<User>();

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.RemoveById(userId);

		Assert.False(result);
		dbContextMock.Verify(db => db.Remove(It.IsAny<User>()), Times.Never);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
	}

	[Fact]
	public async Task RemoveById_ShouldRemoveUsers_WhenUsersExist()
	{
        var userIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
        var users = userIds.Select(id => new User { Id = id }).ToList();

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);
		dbContextMock.Setup(db => db.RemoveRange(It.IsAny<IEnumerable<object>>()))
			.Callback<IEnumerable<object>>(itemsToRemove =>
			{
				var usersToRemove = itemsToRemove.Cast<User>().ToList();
				users.RemoveAll(item => usersToRemove.Contains(item));
			});

        var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.RemoveById(userIds.Skip(1).ToList());

		Assert.True(result);
        Assert.Single(users);

        dbContextMock.Verify(db => db.RemoveRange(It.IsAny<IEnumerable<User>>()), Times.Once);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task RemoveById_ShouldReturnFalse_WhenNoUsersExist()
	{
        var userIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        var users = new List<User>();

		var dbSetMock = CreateDbSetMock(users.AsQueryable());

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

        var result = await repository.RemoveById(userIds);

		Assert.False(result);
		dbContextMock.Verify(db => db.RemoveRange(It.IsAny<IEnumerable<User>>()), Times.Never);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
	}

	[Fact]
	public async Task SavedEntities_ShouldSaveAndReturnEntities()
	{
		var users = new List<User>();

		var dbSetMock = CreateDbSetMock(users.AsQueryable());
		dbSetMock.Setup(db => db.FindAsync(It.IsAny<object[]>())).Returns((object[] itemId) =>
		{
			return new ValueTask<User?>(users.FirstOrDefault(user => user.Id == (Guid)itemId[0]));
		});
		dbSetMock.Setup(db => db.Add(It.IsAny<User>())).Callback<User>(users.Add);

		var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

		var entitiesToSave = new List<User> { new() { Id = Guid.NewGuid() }, new() { Id = Guid.NewGuid() } };
		var result = await repository.SavedEntities(entitiesToSave.Select(item => item.ToEntity()).ToList());

		Assert.Equal(entitiesToSave.Count, users.Count);
		dbSetMock.Verify(db => db.Add(It.IsAny<User>()), Times.Exactly(entitiesToSave.Count));
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task SavedEntity_ShouldSaveAndReturnEntity()
	{
        var users = new List<User>();

        var dbSetMock = CreateDbSetMock(users.AsQueryable());
        dbSetMock.Setup(db => db.FindAsync(It.IsAny<object[]>())).Returns((object[] itemId) =>
        {
            return new ValueTask<User?>(users.FirstOrDefault(user => user.Id == (Guid)itemId[0]));
        });
        dbSetMock.Setup(db => db.Add(It.IsAny<User>())).Callback<User>(users.Add);

        var dbContextMock = new Mock<DefaultDbContext>();
		dbContextMock.Setup(c => c.Set<User>()).Returns(dbSetMock.Object);

		var repository = new UserRepository(dbContextMock.Object);

        var entityToSave = new User { Id = Guid.NewGuid() };
        var result = await repository.SavedEntity(entityToSave.ToEntity());

		Assert.NotNull(result);
		Assert.Single(users);
		dbSetMock.Verify(db => db.Add(It.IsAny<User>()), Times.Once);
		dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
	}

    private static Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> items) where T : class
    {
        var dbSetMock = new Mock<DbSet<T>>();

        dbSetMock.As<IAsyncEnumerable<T>>()
            .Setup(x => x.GetAsyncEnumerator(default))
            .Returns(new TestAsyncEnumerator<T>(items.GetEnumerator()));
        dbSetMock.As<IQueryable<T>>()
            .Setup(m => m.Provider)
            .Returns(new TestAsyncQueryProvider<T>(items.Provider));
        dbSetMock.As<IQueryable<T>>()
            .Setup(m => m.Expression).Returns(items.Expression);
        dbSetMock.As<IQueryable<T>>()
            .Setup(m => m.ElementType).Returns(items.ElementType);
        dbSetMock.As<IQueryable<T>>()
            .Setup(m => m.GetEnumerator()).Returns(items.GetEnumerator());

        return dbSetMock;
    }
}