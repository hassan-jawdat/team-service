using Microsoft.EntityFrameworkCore;
using TeamService.Data;
using TeamService.DTOs;
using TeamService.Services;

namespace TeamService.Tests;

public class TeamServiceTests
{
    private TeamDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<TeamDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new TeamDbContext(options);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsEmptyList_WhenNoMembers()
    {
        var db = CreateDb();
        var service = new global::TeamService.Services.TeamService(db);

        var result = await service.GetAllAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task InviteAsync_AddsMember_AndReturnsDto()
    {
        var db = CreateDb();
        var service = new global::TeamService.Services.TeamService(db);

        var result = await service.InviteAsync(new InviteDto("test@example.com"));

        Assert.Equal("test@example.com", result.Email);
        Assert.Equal("test", result.Name);
        Assert.Equal("Student", result.Role);
    }

    [Fact]
    public async Task DeleteAsync_ReturnsTrue_WhenMemberExists()
    {
        var db = CreateDb();
        var service = new global::TeamService.Services.TeamService(db);

        var member = await service.InviteAsync(new InviteDto("delete@example.com"));
        var result = await service.DeleteAsync(member.Id);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_ReturnsFalse_WhenMemberNotFound()
    {
        var db = CreateDb();
        var service = new global::TeamService.Services.TeamService(db);

        var result = await service.DeleteAsync(999);

        Assert.False(result);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllMembers_AfterInvite()
    {
        var db = CreateDb();
        var service = new global::TeamService.Services.TeamService(db);

        await service.InviteAsync(new InviteDto("a@example.com"));
        await service.InviteAsync(new InviteDto("b@example.com"));

        var result = await service.GetAllAsync();

        Assert.Equal(2, result.Count);
    }
}
