using System.ComponentModel.DataAnnotations;
namespace StudentManagement.ViewModels;
public class CourseRequest
{
    [Required]
    public string? CourseID { get; set; }
    [Required]
    public string? CourseName { get; set; }
    [Required]
    public string? Teacher { get; set; }
}

public class CourseViewModel
{
    public int Id { get; set; }
    public string? CourseID { get; set; }
    public string? CourseName { get; set; }
    public string? Teacher { get; set; }
}