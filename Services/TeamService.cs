using Microsoft.EntityFrameworkCore;
using TeamService.Data;
using TeamService.DTOs;
using TeamService.Models;

namespace TeamService.Services;

public interface ITeamService
{
    Task<List<TeamMemberDto>> GetAllAsync();
    Task<TeamMemberDto> InviteAsync(InviteDto dto);
    Task<bool> DeleteAsync(int id);
}

public class TeamService(TeamDbContext db) : ITeamService
{
    public async Task<List<TeamMemberDto>> GetAllAsync()
    {
        return await db.TeamMembers
            .Select(m => new TeamMemberDto(m.Id, m.Name, m.Email, m.Role))
            .ToListAsync();
    }

    public async Task<TeamMemberDto> InviteAsync(InviteDto dto)
    {
        var member = new TeamMember
        {
            Name = dto.Email.Split('@')[0],
            Email = dto.Email,
            Role = "Student",
            CreatedAt = DateTime.UtcNow,
        };
        db.TeamMembers.Add(member);
        await db.SaveChangesAsync();
        return new TeamMemberDto(member.Id, member.Name, member.Email, member.Role);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var member = await db.TeamMembers.FindAsync(id);
        if (member is null) return false;
        db.TeamMembers.Remove(member);
        await db.SaveChangesAsync();
        return true;
    }
}
