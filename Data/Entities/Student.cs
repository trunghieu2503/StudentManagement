namespace StudentManagement.Data.Entities;
public class Student{
    public int Id {get; set; }
    public string? ImagePath { get; set; }
    public string? StudentId { get; set; }
    public string? StudentName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }
}