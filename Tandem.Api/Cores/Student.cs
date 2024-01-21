namespace Tandem.Api.Cores;

public class Student
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    
    public ICollection<SubGroup> SubGroups { get; set; }
    public ICollection<LearnGroup> LearnGroups { get; set; }
}