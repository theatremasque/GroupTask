namespace Tandem.Api.Core;

public class Group
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public ICollection<AcademicGroup> AcademicGroups { get; set; }
    public ICollection<SubGroup> SubGroups { get; set; }
    public ICollection<LearnGroup> LearnGroups { get; set; }
}