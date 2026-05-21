using Microsoft.EntityFrameworkCore;
using TeamService.Models;

namespace TeamService.Data;

public class TeamDbContext(DbContextOptions<TeamDbContext> options) : DbContext(options)
{
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { Id = 1, Name = "Samantha William", Email = "samantha@gmail.com", Role = "Student", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new TeamMember { Id = 2, Name = "Adam Smith", Email = "adamsmith@gmail.com", Role = "Student", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new TeamMember { Id = 3, Name = "Deven Lane", Email = "info@devenlane.com", Role = "Student", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new TeamMember { Id = 4, Name = "Annette Black", Email = "account@annette.com", Role = "Student", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
