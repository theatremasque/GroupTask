using Microsoft.EntityFrameworkCore;
using Tandem.Api.Cores;

namespace Tandem.Api.Infrastructure;

public class GroupDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<SubGroup> SubGroups { get; set; }
    public DbSet<LearnGroup> LearnGroups { get; set; }
    public GroupDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>()
            .HasOne(s => s.Student)
            .WithMany(g => g.Groups)
            .HasForeignKey(k => k.StudentId);
        
        modelBuilder.Entity<SubGroup>()
            .HasKey(sg => sg.Id);

        modelBuilder.Entity<SubGroup>()
            .HasOne(g => g.Group)
            .WithMany(sg => sg.SubGroups)
            .HasForeignKey(k => k.GroupId);

        modelBuilder.Entity<SubGroup>()
            .HasOne(s => s.Student)
            .WithMany(sg => sg.SubGroups)
            .HasForeignKey(k => k.StudentId);
        
        modelBuilder.Entity<LearnGroup>()
            .HasKey(sg => sg.Id);

        modelBuilder.Entity<LearnGroup>()
            .HasOne(g => g.Group)
            .WithMany(sg => sg.LearnGroups)
            .HasForeignKey(k => k.GroupId);

        modelBuilder.Entity<LearnGroup>()
            .HasOne(s => s.Student)
            .WithMany(sg => sg.LearnGroups)
            .HasForeignKey(k => k.StudentId);
        
        
        base.OnModelCreating(modelBuilder);
    }
}