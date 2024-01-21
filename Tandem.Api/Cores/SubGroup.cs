namespace Tandem.Api.Cores;

public class SubGroup
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int StudentId { get; set; }

    public Group Group { get; set; }
    public Student Student { get; set; }
}