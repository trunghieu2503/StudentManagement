using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Data.Entities;
using StudentManagement.ViewModels;

namespace StudentManagement.Services;
public class StudentService : IStudentService{
    private readonly CourseDbContext _context;
    private readonly IMapper _mapper;

    public StudentService(CourseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<StudentViewModel>> GetAllFilter(string sortOrder, string currentFilter, string searchString, int? courseId, int? pageNumber, int pageSize)
    {
        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        var lessons = from m in _context.Students select m;

        if (courseId != null)
        {
            lessons = lessons.Where(s => s.CourseId == courseId);
        }

        if (!String.IsNullOrEmpty(searchString))
        {
            lessons = lessons.Where(s => s.StudentId!.Contains(searchString)
            || s.StudentName!.Contains(searchString));
        }

        lessons = sortOrder switch
        {
            "title_desc" => lessons.OrderByDescending(s => s.StudentId),
            "date_created" => lessons.OrderBy(s => s.StudentName),
            "date_created_desc" => lessons.OrderByDescending(s => s.StudentName),
            "name_created" => lessons.OrderBy(s => s.StudentName),
            "name_created_desc" => lessons.OrderByDescending(s => s.StudentName),
            _ => lessons.OrderBy(s => s.StudentId),
        };

        return PaginatedList<StudentViewModel>.Create(_mapper.Map<IEnumerable<StudentViewModel>>(await lessons.ToListAsync()), pageNumber ?? 1, pageSize);
    }

    public async Task<int> Create(StudentRequest request)
    {
        var lesson = _mapper.Map<Student>(request);
        _context.Add(lesson);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> Delete(int id)
    {
        var lesson = await _context.Students.FindAsync(id);
        if (lesson != null)
        {
            _context.Students.Remove(lesson);
        }
        return await _context.SaveChangesAsync();
    }
    public async Task<StudentViewModel> GetById(int id)
    {
        var lesson = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<StudentViewModel>(lesson);
    }
    public async Task<int> Update(StudentViewModel request)
    {
        if (!LessonExists(request.Id))
        {
            throw new Exception("Lesson does not exist");
        }
        _context.Update(_mapper.Map<Student>(request));
        return await _context.SaveChangesAsync();
    }
    private bool LessonExists(int id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}