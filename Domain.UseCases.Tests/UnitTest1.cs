using Data.Production.Context;
using Data.Production.Models;
using Data.Production.Repository.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.UseCases.Tests;

public class UnitTest1
{
    private readonly UserRepository _repository;

    public UnitTest1()
    {
        var options = new DbContextOptionsBuilder<DefaultDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var context = new DefaultDbContext(options);
        _repository = new UserRepository(context);
    }

    [Fact]
    public async Task Test1()
    {
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
        }.AsQueryable();

        var options = new DbContextOptionsBuilder<DefaultDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        using var context = new DefaultDbContext(options);
        var initialUsers = new List<User>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Email = "",
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            },
            new()
            {
                Id = Guid.NewGuid(),
                Email = "",
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            },
        };

        context.Users.AddRange(initialUsers);
        context.SaveChanges();

        Assert.Equal(2, context.Users.Count());

        var result = await _repository.RemoveByFilter(new Domain.Entities.Users.UserSearchParams());

        Assert.True(result);
        Assert.Equal(0, context.Users.Count());
    }
}