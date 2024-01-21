using Microsoft.EntityFrameworkCore;
using Tandem.Api.Cores;

namespace Tandem.Api.Infrastructure;

public class GroupDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupType> GroupTypes { get; set; }
    public DbSet<SubGroup> SubGroups { get; set; }
    public DbSet<LearnGroup> LearnGroups { get; set; }
    public GroupDbContext(DbContextOptions options) : base(options) { }
}