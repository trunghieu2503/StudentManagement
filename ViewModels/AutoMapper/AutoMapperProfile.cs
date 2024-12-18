using AutoMapper;
using StudentManagement.Data.Entities;

namespace StudentManagement.ViewModels.AutoMapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Course, CourseViewModel>();
        CreateMap<CourseViewModel, Course>();
        CreateMap<CourseRequest, Course>();

        CreateMap<Student, StudentViewModel>();
        CreateMap<StudentViewModel, Student>();
        CreateMap<StudentRequest, Student>();
    }
}