using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tandem.Api.Infrastructure;

namespace Tandem.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly GroupDbContext _ctx;

    public GroupController(GroupDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public async Task<ActionResult> GetAcademicGroupOfStudent(int studentId)
    {
        var academicGroup = await _ctx.AcademicGroups
        .Where(g => g.StudentId == studentId)
        .Select(s => s.Title)
        .SingleAsync();
        
        return Ok(academicGroup);
    }

    [HttpGet]
    public async Task<ActionResult> GetSubGroupsOfStudent(int studentId)
    {
        var subGroups = await _ctx.SubGroups
            .Where(sub => sub.StudentId == studentId)
            .ToListAsync();

        return Ok(subGroups);
    }

    [HttpGet]
    public async Task<ActionResult> GetLearningGroups(int studentId)
    {
        var learnGroups = await _ctx.LearnGroups
            .Where(sub => sub.StudentId == studentId)
            .ToListAsync();

        return Ok(learnGroups);
    }

    [HttpGet]
    public async Task<ActionResult> GetGroupsOfStudent(int studentId)
    {
        var subGroups = await _ctx.SubGroups
                .Where(w => w.StudentId == studentId)
                .GroupBy(g => g.StudentId)
                .ToDictionaryAsync(k => 
                    k.Key, 
                    values => values.Select(e => e.Title)
                        .ToArray()
                );
        
        var learnGroups = await _ctx.LearnGroups
            .Where(w => w.StudentId == studentId)
            .GroupBy(g => g.StudentId)
            .ToDictionaryAsync(k => 
                    k.Key, 
                values => values.Select(e => e.Title)
                    .ToArray()
            );

        var mergedGroups = subGroups
                .Concat(learnGroups)
                .GroupBy(g => g.Key)
                .ToDictionary(k => 
                    k.Key, 
                    values => values.SelectMany(e => e.Value)
                        .ToArray()
                );
        
        var academicGroup = await _ctx.AcademicGroups
                .Where(s => s.StudentId == studentId)
                .Select(t => t.Title)
                .SingleAsync();
        
        var values = mergedGroups[studentId].Select(s => s).ToList();
            
        values.Add(academicGroup);
        
        return Ok(values);
    }
}