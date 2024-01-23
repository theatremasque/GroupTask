using Microsoft.EntityFrameworkCore;
using Tandem.Api.Core;

namespace Tandem.Api.Infrastructure;

public class TandemDbContext : DbContext
{
    // db func
    public int ActivePostCountForBlog(int blogId) 
        => throw new NotSupportedException();
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<SubGroup> SubGroups { get; set; }
    public DbSet<LearnGroup> LearnGroups { get; set; }
    public DbSet<AcademicGroup> AcademicGroups { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public TandemDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(p => p.Blog);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post);

        modelBuilder.HasDbFunction(typeof(TandemDbContext)
            .GetMethod(nameof(ActivePostCountForBlog),
                new[] { typeof(int) }))
            .HasName("CommentedPostCountForBlog");
        
        
        modelBuilder.Entity<SubGroup>()
            .HasOne(s => s.Student)
            .WithMany(sg => sg.SubGroups)
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
        
        modelBuilder.Entity<AcademicGroup>()
            .HasKey(sg => sg.Id);

        modelBuilder.Entity<AcademicGroup>()
            .HasOne(g => g.Group)
            .WithMany(sg => sg.AcademicGroups)
            .HasForeignKey(k => k.GroupId);

        modelBuilder.Entity<AcademicGroup>()
            .HasOne(s => s.Student)
            .WithMany(sg => sg.AcademicGroups)
            .HasForeignKey(k => k.StudentId);

        modelBuilder.Entity<AcademicGroup>()
            .HasIndex(k => k.StudentId)
            .IsUnique();
        
        
        base.OnModelCreating(modelBuilder);
    }
}