﻿namespace Tandem.Api.Cores;

public class Student
{
    public int Id { get; set; }
    public string? FullName { get; set; }

    public AcademicGroupStudent AcademicGroupStudent { get; set; }
    
    public ICollection<Group> Groups { get; set; }
    public ICollection<SubGroup> SubGroups { get; set; }
    public ICollection<LearnGroup> LearnGroups { get; set; }
}