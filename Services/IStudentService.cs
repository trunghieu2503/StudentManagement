using StudentManagement.ViewModels;

namespace StudentManagement.Services;
public interface IStudentService
{
    Task<PaginatedList<StudentViewModel>> GetAllFilter(string sortOrder, string currentFilter, string searchString, int? courseId, int? pageNumber, int pageSize);
    Task<StudentViewModel> GetById(int id);
    Task<int> Create(StudentRequest request);
    Task<int> Update(StudentViewModel request);
    Task<int> Delete(int id);
}