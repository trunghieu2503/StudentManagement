using StudentManagement.ViewModels;

namespace StudentManagement.Services;
public interface ICoursesService
{
    Task<PaginatedList<CourseViewModel>> GetAllFilter(string sortOrder, string currentFilter, string searchString, int? pageNumber, int pageSize);
    Task<IEnumerable<CourseViewModel>> GetAll();
    Task<CourseViewModel> GetById(int id);
    Task<int> Create(CourseRequest request);
    Task<int> Update(CourseViewModel request);
    Task<int> Delete(int id);
}