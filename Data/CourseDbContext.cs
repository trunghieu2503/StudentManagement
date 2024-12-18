using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data;
public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
    }

    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
}