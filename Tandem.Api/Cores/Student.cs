namespace Tandem.Api.Cores;

public class Student
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    
    public ICollection<Student> Students { get; set; }
}