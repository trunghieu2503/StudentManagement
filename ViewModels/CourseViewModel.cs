using System.ComponentModel.DataAnnotations;
namespace StudentManagement.ViewModels;
public class CourseRequest
{
    [Required(ErrorMessage = "Hãy nhập mã lớp")]
    [Display(Name ="Mã lớp")]
    public string? CourseID { get; set; }
    [Required(ErrorMessage = "Hãy nhập tên lớp")]
    [Display(Name = "Tên lớp")]
    public string? CourseName { get; set; }
    [Required(ErrorMessage = "Hãy nhập tên giáo viên")]
    [Display(Name = "Giáo viên")]
    public string? Teacher { get; set; }
}

public class CourseViewModel
{
    public int Id { get; set; }
    [Display(Name = "Mã lớp")]
    public string? CourseID { get; set; }
    [Display(Name = "Tên lớp")]
    public string? CourseName { get; set; }
    [Display(Name = "Giáo viên")]
    public string? Teacher { get; set; }
}