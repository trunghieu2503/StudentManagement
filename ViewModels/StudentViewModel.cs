using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModels;
public class StudentRequest
{
    public string? StudentId { get; set; }
    public string? StudentName { get; set; }
    public string? Gender { get; set; }
    public int CourseId { get; set; }
}
public class StudentViewModel{
    public int Id { get; set; }
    public string? StudentId { get; set; }
    public string? StudentName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public int CourseId { get; set; }
    public int CourseNAME { get; set; }
}
