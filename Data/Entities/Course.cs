using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagement.Data.Entities;
public class Course
{
    public int Id { get; set; }
    public string? CourseID { get; set; }
    public string? CourseName { get; set; }
    public string? Teacher { get; set; }

    public ICollection<Student>? Students { get; set; }
}
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasMany(e => e.Students)
        .WithOne(e => e.Course)
        .HasForeignKey(e => e.CourseId)
        .HasPrincipalKey(e => e.Id);
    }
}