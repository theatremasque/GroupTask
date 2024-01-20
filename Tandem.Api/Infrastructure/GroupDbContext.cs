using Microsoft.EntityFrameworkCore;

namespace Tandem.Api.Infrastructure;

public class GroupDbContext : DbContext
{
    
    public GroupDbContext(DbContextOptions options) : base(options) { }
}