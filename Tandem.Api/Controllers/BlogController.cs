using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tandem.Api.Infrastructure;

namespace Tandem.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BlogController : ControllerBase
{
    private readonly TandemDbContext _ctx;

    public BlogController(TandemDbContext ctx)
    {
        _ctx = ctx;
    }
    
    [HttpGet]
    public async Task<ActionResult> BlogFunction()
    {
        var q = await _ctx.Blogs.Where(b => _ctx.ActivePostCountForBlog(b.BlogId) > 0)
            .Select(s => s)
            .ToListAsync();
        
        return Ok(q);
    } 
}