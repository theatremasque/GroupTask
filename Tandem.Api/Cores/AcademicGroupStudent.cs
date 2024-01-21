namespace Tandem.Api.Cores;

public class AcademicGroupStudent
{
    public int GroupId { get; set; }
    public int StudentId { get; set; }

    public Student Student { get; set; }
    public Group Group { get; set; }
}