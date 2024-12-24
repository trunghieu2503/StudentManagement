using System.ComponentModel.DataAnnotations;

namespace StudentManagement.ViewModels;
public class StudentRequest
{
    [Required(ErrorMessage = "Hãy chọn ảnh")]
    public IFormFile? Image { get; set; }
    [Required(ErrorMessage = "Hãy nhập mã sinh viên")]
    public string? StudentId { get; set; }
    [Required(ErrorMessage = "Hãy nhập họ tên")]
    public string? StudentName { get; set; }
    [Required(ErrorMessage = "Hãy nhập ngày sinh")]
    public DateTime DateOfBirth { get; set; }
    [Display(Name ="Giới tính")]
    [Required(ErrorMessage = "Hãy chọn giới tính")]
    public string? Gender { get; set; }
    [Required(ErrorMessage = "Hãy chọn khóa học")]
    public int CourseId { get; set; }
}
public class StudentViewModel{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
    [Display(Name = "Mã sinh viên")]
    public string? StudentId { get; set; }
    [Display(Name = "Họ tên")]
    public string? StudentName { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public DateTime DateOfBirth { get; set; }
    [Display(Name = "Giới tính")]
    public string? Gender { get; set; }
    public int CourseId { get; set; }
    public int CourseNAME { get; set; }
}
