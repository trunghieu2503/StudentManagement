using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Entities;

namespace StudentManagement.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new CourseDbContext(serviceProvider.GetRequiredService<DbContextOptions<CourseDbContext>>()))
            {
                
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(
                        new Course { CourseID = "CNTT", CourseName = "Công nghệ thông tin", Teacher = "Nguyễn Thế Vịnh" },
                        new Course { CourseID = "KTPM", CourseName = "Kỹ thuật phần mềm", Teacher = "Phạm Minh Hoàng" },
                        new Course { CourseID = "HTTT", CourseName = "Hệ thống thông tin", Teacher = "Lê Thị Ngọc Lan" },
                        new Course { CourseID = "CNPM", CourseName = "Công nghệ phần mềm", Teacher = "Trần Văn Quý" },
                        new Course { CourseID = "MMT", CourseName = "Mạng máy tính", Teacher = "Nguyễn Văn An" },
                        new Course { CourseID = "ATTT", CourseName = "An toàn thông tin", Teacher = "Vũ Thanh Bình" },
                        new Course { CourseID = "AI", CourseName = "Trí tuệ nhân tạo", Teacher = "Hoàng Thu Hà" },
                        new Course { CourseID = "DLKH", CourseName = "Dữ liệu khoa học", Teacher = "Nguyễn Quốc Trung" },
                        new Course { CourseID = "IOT", CourseName = "Internet of Things", Teacher = "Phạm Văn Thành" },
                        new Course { CourseID = "PTUD", CourseName = "Phát triển ứng dụng", Teacher = "Bùi Thị Hương" },
                        new Course { CourseID = "MOBILE", CourseName = "Lập trình di động", Teacher = "Nguyễn Đình Nam" },
                        new Course { CourseID = "WEB", CourseName = "Lập trình web", Teacher = "Lê Quốc Dũng" },
                        new Course { CourseID = "DBMS", CourseName = "Hệ quản trị cơ sở dữ liệu", Teacher = "Phạm Thị Loan" },
                        new Course { CourseID = "GAMEDEV", CourseName = "Phát triển game", Teacher = "Trần Minh Tuấn" },
                        new Course { CourseID = "HPC", CourseName = "Tính toán hiệu năng cao", Teacher = "Ngô Văn Long" },
                        new Course { CourseID = "CLOUD", CourseName = "Điện toán đám mây", Teacher = "Phạm Thanh Tùng" },
                        new Course { CourseID = "ML", CourseName = "Machine Learning", Teacher = "Lê Minh Châu" },
                        new Course { CourseID = "DL", CourseName = "Deep Learning", Teacher = "Nguyễn Văn Đức" },
                        new Course { CourseID = "SEC", CourseName = "Bảo mật hệ thống", Teacher = "Trần Thị Bích Ngọc" },
                        new Course { CourseID = "ROBOT", CourseName = "Robot và tự động hóa", Teacher = "Đỗ Thế Anh" },
                        new Course { CourseID = "UXUI", CourseName = "Thiết kế giao diện người dùng", Teacher = "Lê Mai Linh" }
                    );
                    context.SaveChanges();
                }

                
                if (!context.Students.Any())
                {
                    var courses = context.Courses.ToList(); 
                    var random = new Random(); 

                    var students = new List<Student>();

                    
                    for (int i = 1; i <= 50; i++)
                    {
                        var course = courses[random.Next(courses.Count)]; 

                        students.Add(new Student
                        {
                            StudentId = $"SV{i:D3}",
                            StudentName = $"Sinh Viên {i}", 
                            DateOfBirth = new DateTime(random.Next(1995, 2005), random.Next(1, 13), random.Next(1, 29)),
                            CourseId = course.Id
                        });
                    }
                    context.Students.AddRange(students);
                    context.SaveChanges();
                }
            }
        }
    }
}
